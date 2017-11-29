using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum status 
{
    patrul = 0,
    serch = 1,
    agresiv = 2,
    stayAgresiv = 3
} 
public class Enemy_1 : BasseEnemy
{

    status isStatus;
    public float HP = 5f;
    public float maxHP = 5f;
    public float attack = 0.1f;

    public float speed = 5f;
    private float memor_speed;
    public float run = 10f;

    public bool inRight = false;

  

    private Rigidbody2D g_Rigidbody2D;
    private SpriteRenderer g_SpriteRenderer;
    private Animator g_Animator;
    private Vector3 direction;


    public Image UIHP;
    public Image UIHP1;

    // Use this for initialization

    void Start()
    {
        direction = transform.right;
        isStatus = status.patrul;
        g_Rigidbody2D = GetComponent<Rigidbody2D>();
        g_SpriteRenderer = GetComponent<SpriteRenderer>();
        g_Animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        g_Rigidbody2D = GetComponent<Rigidbody2D>();
        g_SpriteRenderer = GetComponent<SpriteRenderer>();
        g_Animator = GetComponent<Animator>();
    }
    void CheckGround()
    {
        Collider2D[] colliders1 = Physics2D.OverlapCircleAll(transform.position + transform.up * -1, 0.2F);
     
        foreach (Collider2D c in colliders1)
            if (c.tag == "Ground")
            {
                g_Rigidbody2D.velocity = new Vector2(g_Rigidbody2D.velocity.x, c.transform.position.y + 4);

                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                    c.transform.position.y + 4,
                    gameObject.transform.position.z);

                g_Animator.SetBool("Ground", true);
            }
    }
    // Update is called once per frame
    void Move()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.right * direction.x, 0.2F);

        foreach (Collider2D c in colliders)
            if (c.tag == "Wall" || c.tag == "Ground")
            {
               
                inRight = !inRight;
                direction *= -1.0f;
            }


        CheckGround();

        g_SpriteRenderer.flipX = inRight;
        switch (isStatus)
        {
            case status.agresiv:
                Agresiv();
                break;
            case status.patrul:
                Patrul();
                break;
            case status.serch:
                Serch();
                break;
            case status.stayAgresiv:
                break; 
        }      
    }
    void Agresiv()
    {     
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, run + Time.deltaTime);
        g_Animator.SetFloat("MoveX", run * direction.x);
        g_Animator.SetBool("Run", true);

        //if (inRight)
        //{
        //    g_Rigidbody2D.velocity = new Vector2(-run, g_Rigidbody2D.velocity.y);
        //    g_Animator.SetFloat("MoveX", -run);
        //}
        //else
        //{
        //    g_Rigidbody2D.velocity = new Vector2(run, g_Rigidbody2D.velocity.y);
        //    g_Animator.SetFloat("MoveX", run);
        //}
        //g_Animator.SetBool("Run", true);
    }
    void Patrul()
    {     
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed + Time.deltaTime);
        g_Animator.SetFloat("MoveX", speed * direction.x);
        g_Animator.SetBool("Run", false);

        //if (inRight)
        //{
        //    g_Rigidbody2D.velocity = new Vector2(-speed, g_Rigidbody2D.velocity.y);
        //    g_Animator.SetFloat("MoveX", -speed);
        //}
        //else
        //{
        //    g_Rigidbody2D.velocity = new Vector2(speed, g_Rigidbody2D.velocity.y);
        //    g_Animator.SetFloat("MoveX", speed);
        //}
        //g_Animator.SetBool("Run", false);
    }
    void Serch()
    {

    }
    void ChecPleayr()
    {
        // Collider2D[] colliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + 3f, transform.position.y), new Vector2(2.5f, 7),90);

        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position+transform.right, new Vector2(2.5f, 7), 90);
        foreach (Collider2D c in colliders)
        {
            if (c.tag == "Player1")
            {             
                isStatus = status.agresiv;
                ChecAttack(c);
            }
        }
    }
    void ChecAttack(Collider2D colliders)
    {
        if (colliders.tag == "Player1"&&
            colliders.transform.position.x- transform.position.x>=0&&
            colliders.transform.position.x - transform.position.x <= 2)
        {
            Attack();
        }
    }
    //void ChecWall(Collider2D other)
    //{
    //    if (other.tag == "Wall")
    //    {
    //        inRight = !inRight;

    //    }
    //}

    void FixedUpdate()
    {      
        isStatus = 0;      
        UIHP.fillAmount = HP / 5;
        if (HP <= 0)
        {
            gameObject.SetActive(false);
        }

        ChecPleayr();
        Move();
    }
    public void Damag(float damag)
    {
        HP -= damag;
    }
    void Attack()
    {
        gameObject.GetComponent<Animator>().SetTrigger("attack");
    }
    void OnTriggerEnter2D(Collider2D other)
    {      
       // ChecWall(other);

        if (other.tag == "Ground")
        {
            g_Rigidbody2D.velocity = new Vector2(g_Rigidbody2D.velocity.x, other.transform.position.y + 4);

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 
                other.transform.position.y+4, 
                gameObject.transform.position.z);

            g_Animator.SetBool("Ground", true);
            //isJump = true;
        }
    }
   
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            g_Animator.SetBool("Ground", false);
            // isJump = false;
        }

    }
}
