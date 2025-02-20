using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraForGame : MonoBehaviour //미니 게임 중 카메라가 플레이어를 따라오게 만드는 부분
{
    public Transform target;
    float offsetX; //처음 카메라와 플레이어 간 사이를 저장해두기 위한 변수

    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x; //초반 간격을 저장
    }

    void Update() // 카메라를 따라가도록 하는 부분.
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
