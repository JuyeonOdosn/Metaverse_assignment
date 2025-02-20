using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public GameObject successResult;
    public GameObject failResult;
    public TextMeshProUGUI successScore;
    public TextMeshProUGUI failScore;

    private void Start()
    {
        GameManager.Instance.successResult = successResult;
        GameManager.Instance.failResult = failResult;
        GameManager.Instance.successScore = successScore;
        GameManager.Instance.failScore = failScore;
    }
}
