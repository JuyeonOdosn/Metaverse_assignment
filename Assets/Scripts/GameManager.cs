using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;

    public int Score { get { return currentScore; } }

    private int bestScore = 0;

    public int BestScore { get { return bestScore; } }

    private const string BestScoreKey = "BestScore";

    public GameObject successResult;
    public GameObject failResult;
    public TextMeshProUGUI successScore;
    public TextMeshProUGUI failScore;



    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    public void BackToHome()
    {
        SceneManager.LoadScene(0);

        if(currentScore >= 50)
        {
            successResult.gameObject.SetActive(true);
            successScore.text = currentScore.ToString();
            successScore.gameObject.SetActive(true);
        }
        else
        {
            failResult.gameObject.SetActive(true);
            failScore.text = currentScore.ToString();
            failScore.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        uiManager.ChangeState(UIState.GameOver);
        uiManager.SetGameOverText(currentScore);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }

        Debug.Log("best Score : " + bestScore);
    }


}    