using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScene : MonoBehaviour // 신 전환 할 떄, 값이 null이 되는 현상을 해결하기 위한 클래스
{
    public GameObject successResult; // MainScene 오브젝트에 값을 할당
    public GameObject failResult;
    public TextMeshProUGUI successScore;
    public TextMeshProUGUI failScore;

    private void Start()
    {
        GameManager.Instance.successResult = successResult; // 게임매니저 인스턴스에 있는 개체와 연결시켜 주는 작업
        GameManager.Instance.failResult = failResult;
        GameManager.Instance.successScore = successScore;
        GameManager.Instance.failScore = failScore;
    }
}
