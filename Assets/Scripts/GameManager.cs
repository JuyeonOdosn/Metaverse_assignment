using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    public void BackToHome()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        uiManager.UpdateScore(0);

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    public void GameOver()
    {
        uiManager.ChangeState(UIState.GameOver);
        uiManager.SetGameOverText();
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