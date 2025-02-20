using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BgLooper : MonoBehaviour //배경화면이 연속적으로 생성될 수 있게 만드는 부분입니다.
{
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    public int numBgCount = 5;

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) //  bgLooper와 충돌한 오브젝트를 재생성하기 위한 함수 
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("BackGround")) //대상이 배경일 경우
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>(); 
        if (obstacle) //장애물일 경우
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}