using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float worldScrollingSpeed = 0.2f;

    public Text scoreText;
    public Text coinsText;

    public bool inGame;

    public GameObject restartButton;

    public Immortality immortality;

    float score;
    int coins;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        InitializeGame();
    }

    void InitializeGame()
    {
        inGame = true;

        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
        }
        else
        {
            coins = 0;
        }
        coinsText.text = coins.ToString();
    }

    public void GameOver()
    {
        inGame = false;
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.inGame == false) { return; }

        if((int)score % 100 == 0)
        {
            worldScrollingSpeed += 0.001f;
        }
        score += worldScrollingSpeed;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScore()
    {
        scoreText.text = score.ToString("0");
    }

    public void CoinCollected(int value = 1)
    {
        coins += value;
        PlayerPrefs.SetInt("coins", coins);

        coinsText.text = coins.ToString();

    }

    public void ImmortalityCollected()
    {
        if (immortality.isActive)
        {
            CancelInvoke("CancelImmortality");
            CancelImmortality();
        }

        immortality.isActive = true;
        worldScrollingSpeed += immortality.GetSpeed();

        Invoke("CancelImmortality", immortality.GetDuration());
    }

    void CancelImmortality()
    {
        immortality.isActive = false;
        worldScrollingSpeed -= immortality.GetSpeed();
    }
}
