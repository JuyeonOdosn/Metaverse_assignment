using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction() // 플레이어 이동 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    protected override void Update()
    {
        base.Update();
    }

    
    private void OnTriggerStay2D(Collider2D collision) // Game 태그는 드워프한테만 있다. 드워프를 만났을 때, 미니게임 신으로 전환 하게 만드는 부분
    {
        if (collision.CompareTag("Game"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
                SceneManager.LoadScene(1);
        }
        
    }

}

