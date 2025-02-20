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

    private int currentScore = 0; // ���� ����

    public int Score { get { return currentScore; } }

    private int bestScore = 0; //�ְ� ����

    public int BestScore { get { return bestScore; } }

    private const string BestScoreKey = "BestScore"; // �ְ� ���� ���� ����Ű

    public GameObject successResult;
    public GameObject failResult;
    public TextMeshProUGUI successScore;
    public TextMeshProUGUI failScore;



    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } set { uiManager = value; } }


    private bool isResultActive = false; // ȭ�� ��ȯ�ǰ� �ٽ� ���� ������ �̵����� ��, ���â �����ֱ� ���� bool


    private void Awake()
    {
        if(gameManager == null) // ���ӸŴ��� ����
        {
            gameManager = this;
            DontDestroyOnLoad(this);
        }
        else // �� ��ȯ ��, ���Ӹ޴����� �� ���� ���� �ʵ��� �ϳ��� �����ִ� �κ�
        {
            if(gameManager != this)
             Destroy(this);
        }
                
    }


    private void Update()
    {
        if (isResultActive && (Input.GetMouseButtonDown(0) || Input.anyKeyDown)) // �̴ϰ��ӿ��� �������� ��, ���â�� ���� ���� �κ�.
        {
            CloseResult();
        }
    }

    public void BackToHome() // �̴ϰ��ӿ��� ���� ó�� ���� ������ ���ư��� ���� �κ�.
    {
        SceneManager.LoadScene(0);

        Invoke("ShowResult", 0.5f); // ������ ������ �ʰ� Invoke�� ������Ű��.

    }

    private void ResultShow() // ��� ����
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        uiManager.UpdateScore(0);
    }

    public void GameOver() // �̴ϰ��� ���� ���� �� ȣ��Ǵ� �Լ�
    {
        uiManager.ChangeState(UIState.GameOver);
        uiManager.SetGameOverText(currentScore);
        ResultShow();
    }

    public void AddScore(int score) // �̴ϰ��ӿ��� ��ֹ� �Ѿ��� �� ���� �����ִ� �Լ�.
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);

        if (currentScore > bestScore) // �ְ� ���� ������Ʈ
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }

        Debug.Log("best Score : " + bestScore);
    }


    public void ShowResult() // ���ý����� ���ƿ��� ��, ���â �����ִ� �κ�.
    {
        isResultActive = true;

        if (currentScore >= 50) // ��ǥ������ 50 �� �̻��̸� ���� ���â 
        {
            successResult.gameObject.SetActive(true);
            successScore.text = currentScore.ToString();
            successScore.gameObject.SetActive(true);
        }
        else // ���϶�� ���� ���â
        {
            failResult.gameObject.SetActive(true);
            failScore.text = currentScore.ToString();
            failScore.gameObject.SetActive(true);
        }       
    }

    void CloseResult() // �÷��̾ �̴ϰ��� �������� ���â�� �׸� ���� ���� ��, ȣ��Ǵ� �Լ�
    {
        successResult.SetActive(false);
        failResult.SetActive(false);
        isResultActive = false;

        currentScore = 0; // �̰� �� ������� ������ �ٽ� �����ص� currentScore�� ���µ��� �ʾҴ�. 
    }

}    