using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScene : MonoBehaviour // �� ��ȯ �� ��, ���� null�� �Ǵ� ������ �ذ��ϱ� ���� Ŭ����
{
    public GameObject successResult; // MainScene ������Ʈ�� ���� �Ҵ�
    public GameObject failResult;
    public TextMeshProUGUI successScore;
    public TextMeshProUGUI failScore;

    private void Start()
    {
        GameManager.Instance.successResult = successResult; // ���ӸŴ��� �ν��Ͻ��� �ִ� ��ü�� ������� �ִ� �۾�
        GameManager.Instance.failResult = failResult;
        GameManager.Instance.successScore = successScore;
        GameManager.Instance.failScore = failScore;
    }
}
