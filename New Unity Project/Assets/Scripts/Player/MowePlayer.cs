using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MowePlayer : Unit {

    public Image UIHP;

    Vector3 position;

    private float memor_speed;
    public float run;
    public float jump = 5f;

    private float horizontal = 0; 
    private bool RandL = true;
    private bool isGrounded = false;

    private Animator g_Animator;
    private SpriteRenderer sprite;
    private Rigidbody2D g_Rigidbody2D;

    GameObject Child;
    float times = 0.2f;
    public float speedStopWall=1f;

    public float maxEnerjy = 1f;
    public float maxStamina = 1f;
  
    public float Enerjy = 1f;
    public float Stamina = 1f;

    private void Awake()
    {
        Child = gameObject.transform.Find("Weapon_1").gameObject;


        g_Rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        g_Animator = GetComponent<Animator>();

    }

    // Use this for initialization
    void Start () {
        memor_speed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (freez)
        {
            isGrounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            CheckGrounded();
            HPControl();

            g_Animator.SetBool("Ground", isGrounded);

            //Set the vertical animation
            g_Animator.SetFloat("vSpeed", g_Rigidbody2D.velocity.y);
        }
    }
    void CheckGrounded()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 1.5f), 0.3f);
        foreach (Collider2D c in colliders)
        {
            if (c.tag == "Ground")
            {
                isGrounded = true;
                g_Animator.SetBool("Ground", true);

                return;
            }
            else
            {
                g_Animator.SetBool("Ground", false);
                isGrounded = false;
            }

        }

    }
    private void Update()
    {
        if(Times())
        time=true ;
    }
    public void Move(bool isLeft, bool isRight, bool isDoubleR, bool isDoubleL, bool isJumping, bool isRun, bool isAttact)
    {
        //if (isGrounded)
        //{
        // The Speed animator parameter is set to the absolute value of the horizontal input.
      

        if (isDoubleR || isDoubleL)
            isRun = true;

        if (isRight)
            horizontal = 1f;
        else if (isLeft)
            horizontal = -1f;
        else if (Mathf.Abs(horizontal) <= 0.01)
        {
            horizontal  = 0;
            times = 0.2f;
        }
          


        g_Animator.SetFloat("MoveX", horizontal);
        // Move the character
        g_Rigidbody2D.velocity = new Vector2(horizontal * speed, g_Rigidbody2D.velocity.y);

            if (horizontal > 0)
            {

            if (times > 0)
                times -= Time.deltaTime;
            else 
                times = 0;

                if (isRun)
                {
                    speed = run;
                }
                else
                {
                    speed = memor_speed;
                }
                ///////////////////--------------------------////////////////////////временно не нужно, отслеживает  поворот
                RandL = true;
                g_Animator.SetBool("RandL", RandL);
            ///////////////////--------------------------////////////////////////
            horizontal -= Time.deltaTime + times;
            }
            else if (horizontal < 0)
            {
                if (times > 0)
                    times -= Time.deltaTime;
                else 
                    times = 0;

            if (isRun)
                {
                    speed = run;
                }
                else
                {
                    speed = memor_speed;
                }
                ///////////////////--------------------------////////////////////////временно не нужно, временно не нужно, отслеживает  поворот
                RandL = false;
                g_Animator.SetBool("RandL", RandL);
            ///////////////////--------------------------////////////////////////
            horizontal += Time.deltaTime + times;
            }


           
            // If the input is moving the player right and the player is facing left...
            Corect_flipX(horizontal);
            Corect_flipX_sprite_weapons(horizontal);
        //}

       // Debug.Log();
        // If the player should jump...
        if (isGrounded && isJumping)
        {
            // Add a vertical force to the player.
            isJumping = false;
            g_Animator.SetBool("Ground", false);           
            g_Rigidbody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
        if (isGrounded && isAttact && g_Animator.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            isAttact = false;
            Attack();
        }
    }
    void HPControl()
    {
        UIHP.fillAmount = HELS;

        if (HELS > 1f)
        {
            HELS = 1f;
        }
        if (HELS < 0)
        {
            gameObject.SetActive(false);
        }
    }
    void Attack()
    {
       
            gameObject.GetComponent<Animator>().SetTrigger("attack");

       
    }
    void Corect_flipX_sprite_weapons(float horizontal)
    {
        if (horizontal < 0 || !RandL)
            Child.transform.position = new Vector3(transform.position.x - 1.9f, Child.transform.position.y, Child.transform.position.z);
        else
            Child.transform.position = new Vector3(transform.position.x + 1.9f, Child.transform.position.y, Child.transform.position.z);
    }
    void Corect_flipX(float horizontal)
    {
        if (horizontal < 0 || !RandL)
            sprite.flipX = !RandL;
        else
            sprite.flipX = position.x < 0;
    }
    public override void ReciveDamage(float damag)
    {

        if (time)
        {
            HELS -= damag;
            time = false;
        }
       
    }
    private bool time=false;
    public float timer = 2f;
    public float stay_timer = 2f;
    bool Times()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return false;
        }
        else if (timer < 0)
        {
            timer = stay_timer;
            return true;
        }
        return false;
    }

}
