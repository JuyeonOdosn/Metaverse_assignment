using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraForGame : MonoBehaviour //�̴� ���� �� ī�޶� �÷��̾ ������� ����� �κ�
{
    public Transform target;
    float offsetX; //ó�� ī�޶�� �÷��̾� �� ���̸� �����صα� ���� ����

    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x; //�ʹ� ������ ����
    }

    void Update() // ī�޶� ���󰡵��� �ϴ� �κ�.
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
