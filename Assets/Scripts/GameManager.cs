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

    private int currentScore = 0; // 현재 점수

    public int Score { get { return currentScore; } }

    private int bestScore = 0; //최고 점수

    public int BestScore { get { return bestScore; } }

    private const string BestScoreKey = "BestScore"; // 최고 점수 담을 문자키

    public GameObject successResult;
    public GameObject failResult;
    public TextMeshProUGUI successScore;
    public TextMeshProUGUI failScore;



    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } set { uiManager = value; } }


    private bool isResultActive = false; // 화면 전환되고 다시 샘플 신으로 이동했을 때, 결과창 보여주기 위한 bool


    private void Awake()
    {
        if(gameManager == null) // 게임매니저 생성
        {
            gameManager = this;
            DontDestroyOnLoad(this);
        }
        else // 신 전환 시, 게임메니저가 두 개가 되지 않도록 하나를 없애주는 부분
        {
            if(gameManager != this)
             Destroy(this);
        }
                
    }


    private void Update()
    {
        if (isResultActive && (Input.GetMouseButtonDown(0) || Input.anyKeyDown)) // 미니게임에서 복귀했을 때, 결과창을 끄기 위한 부분.
        {
            CloseResult();
        }
    }

    public void BackToHome() // 미니게임에서 게임 처음 시작 신으로 돌아가기 위한 부분.
    {
        SceneManager.LoadScene(0);

        Invoke("ShowResult", 0.5f); // 순서가 꼬이지 않게 Invoke로 지연시키기.

    }

    private void ResultShow() // 결과 저장
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        uiManager.UpdateScore(0);
    }

    public void GameOver() // 미니게임 게임 오버 시 호출되는 함수
    {
        uiManager.ChangeState(UIState.GameOver);
        uiManager.SetGameOverText(currentScore);
        ResultShow();
    }

    public void AddScore(int score) // 미니게임에서 장애물 넘었을 때 점수 더해주는 함수.
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);

        if (currentScore > bestScore) // 최고 점수 업데이트
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }

        Debug.Log("best Score : " + bestScore);
    }


    public void ShowResult() // 샘플신으로 돌아왔을 때, 결과창 보여주는 부분.
    {
        isResultActive = true;

        if (currentScore >= 50) // 목표점수인 50 점 이상이면 성공 결과창 
        {
            successResult.gameObject.SetActive(true);
            successScore.text = currentScore.ToString();
            successScore.gameObject.SetActive(true);
        }
        else // 이하라면 실패 결과창
        {
            failResult.gameObject.SetActive(true);
            failScore.text = currentScore.ToString();
            failScore.gameObject.SetActive(true);
        }       
    }

    void CloseResult() // 플레이어가 미니게임 성공실패 결과창을 그만 보고 싶을 때, 호출되는 함수
    {
        successResult.SetActive(false);
        failResult.SetActive(false);
        isResultActive = false;

        currentScore = 0; // 이걸 안 해줬더니 게임을 다시 시작해도 currentScore가 리셋되지 않았다. 
    }

}    