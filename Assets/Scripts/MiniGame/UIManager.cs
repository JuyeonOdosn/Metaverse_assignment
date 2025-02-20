using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;


public enum UIState
{
    Start,
    Game,
    GameOver
}
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI gameScoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject IntroPanel;
    public TextMeshProUGUI introText;
    public Button startButton;

   

    static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }

    UIState currentState = UIState.Start;

    public UIState CurrentState
    {
        get { return currentState; }
    }

    StartUI startUI = null;
    GameUI gameUI = null;
    GameOverUI gameOverUI = null;

    Player player = null;

    private void Awake()
    {
        instance = this;

        player = FindObjectOfType<Player>();

        startUI = GetComponentInChildren<StartUI>(true);
        startUI?.Init(this);

        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this);

        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI?.Init(this);

        ChangeState(UIState.Start);

    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        startUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);

        if (currentState == UIState.Start)
        {
            Time.timeScale = 0; 
        }
        else if (currentState != UIState.Start)
        {
            Time.timeScale = 1; 
        }
    }

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

    public void SetGameOverText(int currentScore)
    {
        gameoverText.gameObject.SetActive(true);
        gameScoreText.text = currentScore.ToString();
        gameScoreText.gameObject.SetActive(true);
        bestScoreText.text = GameManager.Instance.BestScore.ToString();
        bestScoreText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void OnClickStart()
    {
        Time.timeScale = 1;
        ChangeState(UIState.Game);
    }

}