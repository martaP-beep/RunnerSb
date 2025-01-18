using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float worldScrollingSpeed = 0.2f;

    public Text scoreText;
    float score;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void FixedUpdate()
    {
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
