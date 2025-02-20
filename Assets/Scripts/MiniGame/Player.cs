using UnityEngine;

public class Player : MonoBehaviour 
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;

        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (animator == null) // 예외 처리
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (UIManager.Instance != null && UIManager.Instance.CurrentState == UIState.Start) //startUI를 종료 한 후에 게임이 시작될 수 있도록하는 부분.
            return;

        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                gameManager.GameOver(); //죽으면 게임오버

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //게임오버창이 뜬 후 사용자의 입력 
                {
                    gameManager.BackToHome(); //입력이 있다면 원래 Sample Scene으로 돌아가기
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime; 
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead || UIManager.Instance != null && UIManager.Instance.CurrentState != UIState.Game) //앞선 업데이트 함수와 마찬가지 StartUI 종료 후에 진행되도록. Fixed Update라서 여기서도 안 하면 소용이 없다.
            return;


        Vector3 velocity = _rigidbody.velocity; //속도
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90); //플레이어의 방향 전환 각도
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision) //플레이어가 부딪쳤을 때 함수
    {
        if (godMode)
            return;

        if (isDead)
            return;

        animator.SetInteger("IsDie", 1); //애니메이션은 죽은 걸로 뜨게 만들기
        isDead = true; //죽었다
        deathCooldown = 1f; //1초 뒤에 게임 종료 화면
    }
}