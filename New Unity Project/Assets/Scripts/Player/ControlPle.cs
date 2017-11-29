using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
using UnityEngine.UI;

public class ControlPle : Unit
{
    public Image UIHP;

    Vector3 position;

    

    public float speed = 5f;
    private float memor_speed;
    public float run;

    
    public float jump = 5f;
    private float moveX;
    private bool isDown = false;
    private bool RandL = true;
    private bool isGrounded = false;

    private Animator gameG;
    private SpriteRenderer sprite;
    private Rigidbody2D g_Rigidbody2D;

    GameObject Child;
  
    public float maxHELS = 1f;   
    public float maxEnerjy = 1f;  
    public float maxStamina = 1f;

   
    public float HELS = 1f;   
    public float Enerjy = 1f;  
    public float Stamina = 1f;

    // Use this for initialization
    void Start()
    {            
        memor_speed = speed;       
    }
    private void Awake()
    {
       Child = gameObject.transform.Find("Weapon_1").gameObject;
        //sprite_weapons = Child.GetComponent<SpriteRenderer>(); //времено

        g_Rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        gameG = GetComponent<Animator>();
       
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
    public void Damag(float damag)
    {
        HELS -= damag;
    }
    void Move()
    {
        //////////////////////////////////////////////////////////////////////////////
        gameG.SetFloat("vSpeed", g_Rigidbody2D.velocity.y);
        transform.position += position * Time.deltaTime * speed;
        //////////////////////////////////////////////////////////////////////////////
            Corect_flipX();
            Corect_flipX_sprite_weapons();
           
            position = new Vector3(CnInputManager.GetAxis("Horizontal"), 0f, 0f);
            if (position.x > 0)
            {
                if(CnInputManager.GetButton("Run"))
                {
                    speed = run;             
                }
                else
                {             
                    speed = memor_speed;             
                }              
                ///////////////////--------------------------////////////////////////временно не нужно, отслеживает  поворот
                RandL = true;
                gameG.SetBool("RandL", RandL);
                ///////////////////--------------------------////////////////////////
            }
            else if (position.x < 0)
            {
                if (CnInputManager.GetButton("Run"))
                {
                    speed = run;               
                }
                else
                {
                    speed = memor_speed;               
                }             
                ///////////////////--------------------------////////////////////////временно не нужно, временно не нужно, отслеживает  поворот
                RandL = false;
                gameG.SetBool("RandL", RandL);
                ///////////////////--------------------------////////////////////////
            }        
                gameG.SetFloat("MoveX", position.x, 0.1f, Time.deltaTime);
                    
            Jupm();
            Attack();                     
    }
    //////////////////////////////////////////////////////////////////////////////
    void Attack()
    {
        if (CnInputManager.GetButtonUp("Attack"))
        {        
            gameObject.GetComponent<Animator>().SetTrigger("attack");
                   
        }
    }
    //////////////////////////////////////////////////////////////////////////////

    void Corect_flipX_sprite_weapons()
    {
        if (position.x < 0 || !RandL)
            Child.transform.position = new Vector3(transform.position.x - 1.9f, Child.transform.position.y, Child.transform.position.z);
        else
            Child.transform.position = new Vector3(transform.position.x + 1.9f, Child.transform.position.y, Child.transform.position.z);
    }
    void Corect_flipX()
    {  
        if(position.x < 0 || !RandL)
        sprite.flipX = !RandL;   
        else
        sprite.flipX = position.x < 0;
    }

    //////////////////////////////////////////////////////////////////////////////
  
    //////////////////////////////////////////////////////////////////////////////
    void Jupm()
    {        
        if (CnInputManager.GetButtonUp("Jump") && isGrounded)
        {         
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);         
        }
    }
    //////////////////////////////////////////////////////////////////////////////

    void CheckGrounded()
    {
      
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x,transform.position.y - 1.5f),0.3f);
        foreach (Collider2D c in colliders)
        {
            if (c.tag == "Ground")
            {
                isGrounded = true;
                gameG.SetBool("Ground", true);
              
                return;
            }
            else
            {
                gameG.SetBool("Ground", false);
                isGrounded = false;
            }
                              
        }
        
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGrounded();
        HPControl();
            Move();                 
    }   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            gameG.SetBool("Ground", true);
            isGrounded = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            gameG.SetBool("Ground", false);
            isGrounded = false;      
        }
    
    }


}

