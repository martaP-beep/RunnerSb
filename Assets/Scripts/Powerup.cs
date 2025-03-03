using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    [SerializeField]
    protected int[] UpgradeCosts;

    [SerializeField]
    protected int currentLevel = 1;

    [SerializeField]
    protected int maxLevel = 3;


    public bool isActive;

    [SerializeField]
    protected PowerupStats duration;


    private void Awake()
    {
        LoadPowerupLevel();
    }

    public float GetDuration()
    {
        return duration.GetValue(currentLevel);
    }

    public bool IsMaxedOut()
    {
        return currentLevel == maxLevel;
    }

    public int GetNextUpgradeCost()
    {
        if (IsMaxedOut() == false)
        {

            return UpgradeCosts[currentLevel - 1];
        }
        else
        {
            return -1;
        }
    }

    public void Upgrade()
    {
        if (IsMaxedOut()) { return; }

        currentLevel++;
        SavePowerupLevel();
    }

    void SavePowerupLevel()
    {
        string key = name + "Level";
        PlayerPrefs.SetInt(key, currentLevel);
    }

    void LoadPowerupLevel()
    {
        string key = name + "Level";
        if (PlayerPrefs.HasKey(key)) {
        currentLevel = PlayerPrefs.GetInt(key);
        }
    }

    public override string ToString()
    {
        string text = $"{name}\n Lvl.{currentLevel}";
        if (IsMaxedOut())
        {
            text += " MAX";
        }
        return text;

    }
    public string UpgradeCostString()
    {
        if (IsMaxedOut())
        {
            return "MAXED OUT";
        }
        else
        {
            return $"UPGRADE \nCOST: {GetNextUpgradeCost()}";
        }
    }


}
