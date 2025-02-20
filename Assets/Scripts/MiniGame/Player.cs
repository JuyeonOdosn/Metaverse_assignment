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

        if (animator == null) // ���� ó��
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
        if (UIManager.Instance != null && UIManager.Instance.CurrentState == UIState.Start) //startUI�� ���� �� �Ŀ� ������ ���۵� �� �ֵ����ϴ� �κ�.
            return;

        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                gameManager.GameOver(); //������ ���ӿ���

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //���ӿ���â�� �� �� ������� �Է� 
                {
                    gameManager.BackToHome(); //�Է��� �ִٸ� ���� Sample Scene���� ���ư���
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
        if (isDead || UIManager.Instance != null && UIManager.Instance.CurrentState != UIState.Game) //�ռ� ������Ʈ �Լ��� �������� StartUI ���� �Ŀ� ����ǵ���. Fixed Update�� ���⼭�� �� �ϸ� �ҿ��� ����.
            return;


        Vector3 velocity = _rigidbody.velocity; //�ӵ�
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90); //�÷��̾��� ���� ��ȯ ����
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision) //�÷��̾ �ε����� �� �Լ�
    {
        if (godMode)
            return;

        if (isDead)
            return;

        animator.SetInteger("IsDie", 1); //�ִϸ��̼��� ���� �ɷ� �߰� �����
        isDead = true; //�׾���
        deathCooldown = 1f; //1�� �ڿ� ���� ���� ȭ��
    }
}