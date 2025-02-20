using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;


public enum UIState // �̴ϰ��� �� ȭ����ȯ�� ���� ����
{
    Start,
    Game,
    GameOver
}
public class UIManager : MonoBehaviour //���� ����, �ְ� ����, ���� ���� ���� ǥ���ϱ� ���� Ŭ����
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

    UIState currentState = UIState.Start; //ó�� ������ StartUI

    public UIState CurrentState
    {
        get { return currentState; }
    }

    StartUI startUI = null;
    GameUI gameUI = null;
    GameOverUI gameOverUI = null;

    Player player = null;

    private void Awake() // �� �Ҵ�
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

    public void ChangeState(UIState state) // UI��ȯ�� ���� �Լ�
    {
        currentState = state;
        startUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);

        if (currentState == UIState.Start) //UIState�� ������ �� ������ ����Ǹ� �� �Ǵϱ� 0���� ����� ���Ҵ�.
        {
            Time.timeScale = 0; 
        }
        else if (currentState != UIState.Start) //�������� ���� ����. ���� ������ ���Ŀ��� Ŭ���� ������ ������ �׳� ���� ���� ���·� �ξ���. 
        {
            Time.timeScale = 1; 
        }
    }

    public void Start()
    {
        gameoverText.gameObject.SetActive(false); //���� ȭ�� ���ΰ�
        introText.gameObject.SetActive(true); //���� ȭ�� Ű��

        GameManager.Instance.UIManager = this;
    }

    public void SetGameOverText(int currentScore) //���� ������ ȣ�� �� �Լ�
    {
        gameoverText.gameObject.SetActive(true);
        gameScoreText.text = currentScore.ToString();
        gameScoreText.gameObject.SetActive(true);
        bestScoreText.text = GameManager.Instance.BestScore.ToString();
        bestScoreText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score) //���� ���� �� ���ھ� ������Ʈ
    {
        scoreText.text = score.ToString();
    }

    public void OnClickStart() //StartUI ���� Ŭ���ϸ� ���� ���۰� �Բ� gameUI�� �ٲ�� �κ�.
    {
        Time.timeScale = 1;
        ChangeState(UIState.Game);
    }

}