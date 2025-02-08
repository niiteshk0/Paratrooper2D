using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    int score = 0;
    int highscore;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

  
    void Start()
    {
        UpdateScoreText();
        LoadHighScore();
    }

    public void AddScore(int points)
    {
        Debug.Log("Score Increasing");
        score += points;
        UpdateScoreText();
    }
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();

        if(score > highscore)
        {
            highscore = score;
            highScoreText.text = score.ToString();
            SaveHighScore();
        }
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HS", highscore);
        PlayerPrefs.Save();
    }

    void LoadHighScore()
    {
        highscore = PlayerPrefs.GetInt("HS", 0);
        highScoreText.text = highscore.ToString();
    }
}
