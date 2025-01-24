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

    public bool inGame;

    public GameObject restartButton;

    float score;

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
}
