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

    public Text magnetLevelText;
    public Text magnetButtonText;

    public Text immortalityLevelText;
    public Text immortalityButtonText;

    public Powerup magnet;
    public Powerup immortality;

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

        immortalityLevelText.text = immortality.ToString();
        immortalityButtonText.text = immortality.UpgradeCostString();

        magnetLevelText.text = magnet.ToString();
        magnetButtonText.text = magnet.UpgradeCostString();

        if (SoundManager.instance.GetMuted())
        {
            soundText.text = "Turn on sound";
        }
        else
        {
            soundText.text = "Turn off sound";
        }

    }

    public void SoundButton()
    {
        SoundManager.instance.ToggleMuted();
        UpdateUI();
    }


    void UpgradePowerup(Powerup powerup)
    {
        if(coins >= powerup.GetNextUpgradeCost() 
            && powerup.IsMaxedOut() == false)
        {
            powerup.Upgrade();
            coins -= powerup.GetNextUpgradeCost();
            PlayerPrefs.SetInt("coins", coins);
            UpdateUI();
        }
    }
    public void UpgradeMagnetButton()
    {
        UpgradePowerup(magnet);
    }
    public void UpgradeImmortality()
    {
        UpgradePowerup(immortality);
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
