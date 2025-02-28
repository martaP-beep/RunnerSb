using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject storePanel;

    public Text coinText;
    public Text soundText;

    int coins;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
        }
        else
        {
            coins = 0;
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = "Coins: " + coins;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenStore()
    {
        Debug.Log("Klik");

        menuPanel.SetActive(false);
        storePanel.SetActive(true);
    }
    public void CloseStore()
    {
        menuPanel.SetActive(true);
        storePanel.SetActive(false);
    }
}
