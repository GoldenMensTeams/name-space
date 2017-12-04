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
 
    public float attack = 0.1f;

  
   
    public float run = 10f;

    public bool inRight = false;

    private Rigidbody2D g_Rigidbody2D;
    private SpriteRenderer g_SpriteRenderer;
    private Animator g_Animator;
    private Vector3 direction;

    GameObject Child;

    public Image UIHP=null;
    

    // Use this for initialization

    void Start()
    {
        direction = transform.right;
        isStatus = status.patrul;

        GameObject [] g_Object;
        g_Object = GameObject.FindGameObjectsWithTag("Player1");

        if(g_Object.Length != 0 )
        {
            Transform player = g_Object[0].transform;
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
      
        g_Object = GameObject.FindGameObjectsWithTag("Enemy");

        if (g_Object.Length != 0)
        {
            foreach (GameObject e in g_Object)
            {
                Transform player = e.transform;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }

    }
    private void Awake()
    {
        Child = gameObject.transform.Find("Attact").gameObject;
              

        g_Rigidbody2D = GetComponent<Rigidbody2D>();
        g_SpriteRenderer = GetComponent<SpriteRenderer>();
        g_Animator = GetComponent<Animator>();
    }
    void CheckGround()
    {
        Collider2D[] colliders1 = Physics2D.OverlapCircleAll(transform.position + transform.up * -1, 0.2F);
        g_Animator.SetBool("Ground", false);

        foreach (Collider2D c in colliders1)
            if (c.tag == "Ground")
            {
               /// c.transform.position.y + 2
               // g_Rigidbody2D.velocity = new Vector2(g_Rigidbody2D.velocity.x, c.transform.position.y + (transform.position.y - c.transform.position.y));


                ///c.transform.position.y + 4,
                //transform.position = new Vector3(transform.position.x,
                //    c.transform.position.y + (transform.position.y - c.transform.position.y) * 2,
                //  transform.position.z);

                g_Animator.SetBool("Ground", true);

              
            }
       
    }
    void ChecWall()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.right * direction.x, 0.2F);
        foreach (Collider2D c in colliders)
            if (c.tag == "Wall" || c.tag == "Ground")
            {
                Debug.Log("Wall");
                inRight = !inRight;
                direction *= -1.0f;
            }
    }
    void Corect_flipX_sprite_weapons()
    {
        if (!inRight)
            Child.transform.position = new Vector3(transform.position.x + 1.8f, Child.transform.position.y, Child.transform.position.z);
        else
            Child.transform.position = new Vector3(transform.position.x - 1.8f, Child.transform.position.y, Child.transform.position.z);
    }
    // Update is called once per frame
    void Move()
    {
        ChecWall();
        CheckGround();

        g_SpriteRenderer.flipX = inRight;
        Corect_flipX_sprite_weapons();


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
           
        }      
    }
    void Agresiv()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + transform.right * 3f * direction.x, new Vector2(2.5f, 7), 90);
       
        foreach (Collider2D c in colliders)
        {
            if (c.tag == "Player1" &&
               Mathf.Abs(c.transform.position.x - transform.position.x) >= 2)
            { 
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, run + Time.deltaTime);
                    g_Animator.SetFloat("MoveX", run * direction.x);
                    g_Animator.SetBool("Run", true);
            }
            else if (c.tag == "Player1" &&
                    Mathf.Abs(c.transform.position.x - transform.position.x) < 2 &&
                    Mathf.Abs(c.transform.position.x - transform.position.x) >= 0)
                 {
                    g_Animator.SetFloat("MoveX", 0);
                    g_Animator.SetBool("Run", false);
                 }
        }
    }
    void Patrul()
    {     
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed + Time.deltaTime);
        g_Animator.SetFloat("MoveX", speed * direction.x);
        g_Animator.SetBool("Run", false);     
    }
    void Serch()
    {

    }
    void ChecPleayr()
    {      
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position+transform.right*3f * direction.x, new Vector2(2.5f, 7), 90);
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
            Mathf.Abs(colliders.transform.position.x- transform.position.x)>=0&&
             Mathf.Abs(colliders.transform.position.x - transform.position.x) <= 2)
        {
            Attack();
        }
    }
    

    void FixedUpdate()
    {      
        isStatus = 0;      

     
      
        UIHP.fillAmount = HELS;
        if (HELS <= 0)
        {
           
            Destroy(gameObject);
        }

        ChecPleayr();
        Move();
    }

    public override void ReciveDamage(float _damag)
    {
        HELS -= _damag;
    }
    public void Damag(float damag)
    {
        HELS -= damag;
    }
    void Attack()
    {
        gameObject.GetComponent<Animator>().SetTrigger("attack");
    }
    void OnTriggerEnter2D(Collider2D other)
    {      
       // ChecWall(other);

        //if (other.tag == "Ground")
        //{
        //    g_Rigidbody2D.velocity = new Vector2(g_Rigidbody2D.velocity.x, other.transform.position.y + 4);

        //    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 
        //        other.transform.position.y+4, 
        //        gameObject.transform.position.z);

        //    g_Animator.SetBool("Ground", true);
        //    //isJump = true;
        //}
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
