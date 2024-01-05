using UnityEngine;

public class WalkingMonster : Entity
{
    private float speed = 3.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;
    /*private bool isGrounded = false;

    private Animator anim;

    private Walking Walk 
    {
        get { return (Walking)anim.GetInteger("walk"); }
        set { anim.SetInteger("walk", (int)value); }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }*/

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        dir = transform.right; // указываем начальное направление
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        //if (isGrounded) Walk = Walking.walk; 

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 5f, 0.1f);

        if (colliders.Length > 0) dir *= -1f;
        //transform.Translate(dir * speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
        sprite.flipX = dir.x > 0.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == PlayerController.Instance.gameObject)
            PlayerController.Instance.GetDamage();
    }
}

/*public enum Walking 
{
    walk
}*/
