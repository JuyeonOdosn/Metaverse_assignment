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
    public UIManager UIManager { get { return uiManager; } set { uiManager = value; } }


    private bool isResultActive = false;


    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(gameManager != this)
             Destroy(this);
        }
                
    }


    private void Update()
    {
        if (isResultActive && (Input.GetMouseButtonDown(0) || Input.anyKeyDown))
        {
            CloseResult();
        }
    }

    public void BackToHome()
    {
        SceneManager.LoadScene(0);

        Invoke("ShowResult", 0.5f);

    }

    private void ResultShow()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        uiManager.ChangeState(UIState.GameOver);
        uiManager.SetGameOverText(currentScore);
        ResultShow();
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


    public void ShowResult()
    {
        isResultActive = true;

        if (currentScore >= 50)
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

    void CloseResult()
    {
        successResult.SetActive(false);
        failResult.SetActive(false);
        isResultActive = false;

        currentScore = 0;
    }

}    