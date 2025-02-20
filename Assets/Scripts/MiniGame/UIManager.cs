using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;


public enum UIState // 미니게임 속 화면전환을 위한 관리
{
    Start,
    Game,
    GameOver
}
public class UIManager : MonoBehaviour //게임 설명, 최고 점수, 현재 점수 등을 표현하기 위한 클래스
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

    UIState currentState = UIState.Start; //처음 시작은 StartUI

    public UIState CurrentState
    {
        get { return currentState; }
    }

    StartUI startUI = null;
    GameUI gameUI = null;
    GameOverUI gameOverUI = null;

    Player player = null;

    private void Awake() // 값 할당
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

    public void ChangeState(UIState state) // UI전환을 위한 함수
    {
        currentState = state;
        startUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);

        if (currentState == UIState.Start) //UIState만 시작할 때 게임이 진행되면 안 되니까 0으로 만들어 놓았다.
        {
            Time.timeScale = 0; 
        }
        else if (currentState != UIState.Start) //나머지는 게임 진행. 게임 종료한 이후에는 클릭이 먹히지 않으니 그냥 게임 진행 상태로 두었다. 
        {
            Time.timeScale = 1; 
        }
    }

    public void Start()
    {
        gameoverText.gameObject.SetActive(false); //종료 화면 꺼두고
        introText.gameObject.SetActive(true); //시작 화면 키기

        GameManager.Instance.UIManager = this;
    }

    public void SetGameOverText(int currentScore) //게임 오버시 호출 될 함수
    {
        gameoverText.gameObject.SetActive(true);
        gameScoreText.text = currentScore.ToString();
        gameScoreText.gameObject.SetActive(true);
        bestScoreText.text = GameManager.Instance.BestScore.ToString();
        bestScoreText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score) //게임 진행 중 스코어 업데이트
    {
        scoreText.text = score.ToString();
    }

    public void OnClickStart() //StartUI 에서 클릭하면 게임 시작과 함께 gameUI로 바뀌는 부분.
    {
        Time.timeScale = 1;
        ChangeState(UIState.Game);
    }

}