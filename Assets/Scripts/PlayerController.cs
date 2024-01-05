using UnityEngine;

public class PlayerController : Entity
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 3;
    [SerializeField] private float jumpForce = 15f;
    private bool isGrounded = false;

    // ссылки на компоненты
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    public static PlayerController Instance { get; set; }  // это строчка реализации паттерна Singleton

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
   
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround(); // вызываем этот метод здесь чтоб у нас не было никаких казусов
    }

    private void Update()
    {
        if (isGrounded) State = States.idle;

        if (Input.GetButton("Horizontal"))
            Run();

        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.8f);
        isGrounded = collider.Length > 1; // если у нас длина массива больше одного, значит мы на земле

        if (!isGrounded) State = States.jump;
    }

    private void Run()
    {
        if (isGrounded) State = States.run;

        Vector3 hor = transform.right * Input.GetAxis("Horizontal");
        // "transform.position" - текущие местоположение, "transform.position + hor" - куда надо переместиться
        transform.position = Vector3.MoveTowards(transform.position, transform.position + hor, speed * Time.deltaTime);

        sprite.flipX = hor.x < 0.0f; // поварачиваем персонажа влево
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    public override void GetDamage() 
    {
        lives -= 1;
        Debug.Log(lives);
    }
}

public enum States
{
    idle, // 0
    run,  // 1
    jump  // 2
}
