using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public GameObject IntroPanel;
    public TextMeshProUGUI introText;
    public Button startButton;

    public void Start()
    {
        if (gameoverText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        gameoverText.gameObject.SetActive(false);
        introText.gameObject.SetActive(true);
    }

    public void SetGameOverText()
    {
        gameoverText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}