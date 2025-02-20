using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour // Sample Scene에서 플레이어를 카메라가 계속 비춰주도록 만드는 클래스
{
    public Transform player; 
    float offsetX;
    float offsetY;

    void Start()
    {
        if (player == null)
            return;

        offsetX = transform.position.x - player.position.x;
        offsetY = transform.position.y - player.position.y;
        
    }

    void Update()
    {
        if (player == null)
            return;

        Vector3 pos = transform.position; 
        pos.x = player.position.x + offsetX; 
        pos.y = player.position.y + offsetY;
        transform.position = pos;
    }
}