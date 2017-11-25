using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
using UnityEngine.UI;

public class ControlPle : MonoBehaviour
{
    public Image UIHP;

    Vector3 position;

    [SerializeField]
    public float speed = 5f;

    private float memor_speed;

    [SerializeField]
    public float run;

    [SerializeField]
    public float jump = 5f;
    private float moveX;
    private bool isJump = true;
    private bool ImisJump=false;
    private bool isDown = false;
    private bool RandL = true;

    private Animator gameG;
    private SpriteRenderer sprite;

    private SpriteRenderer sprite_weapons;   //времено
    GameObject Child;


    [SerializeField]
    public float maxHELS = 1f;
    [SerializeField]
    public float maxEnerjy = 1f;
    [SerializeField]
    public float maxStamina = 1f;

    [SerializeField]
    public float HELS = 1f;
    [SerializeField]
    public float Enerjy = 1f;
    [SerializeField]
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
          //  Instantiate(Ragdole, transform.position, transform.rotation);
        }
     
    }
    public void Damag(float damag)
    {
        HELS -= damag;
    }
    void Move()
    {
        //////////////////////////////////////////////////////////////////////////////
      
        transform.position += position * Time.deltaTime * speed;
        //////////////////////////////////////////////////////////////////////////////

       // if (isJump)
       // {

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

                gameG.SetFloat("MoveX", position.x, 0.1f, Time.deltaTime);
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

                gameG.SetFloat("MoveX", position.x, 0.1f, Time.deltaTime);
                ///////////////////--------------------------////////////////////////временно не нужно, временно не нужно, отслеживает  поворот
                RandL = false;
                gameG.SetBool("RandL", RandL);
                ///////////////////--------------------------////////////////////////
            }
            else if (position.x == 0)
            {
                gameG.SetFloat("MoveX", position.x, 0.1f, Time.deltaTime);
            }
            //////////////////////////////////////////////////////////////////////////////

            Jupm();
            Attack();
            //////////////////////////////////////////////////////////////////////////////
          
      //  }
       
    }
    //////////////////////////////////////////////////////////////////////////////
    void Attack()
    {
        if (CnInputManager.GetButtonUp("Attack"))
        {

          
            gameObject.GetComponent<Animator>().SetTrigger("attack");
          
            //if (isJump)
            //{
            //    gameObject.GetComponent<Animator>().SetTrigger("idle");
            //}
            //else
            //{
            //    gameObject.GetComponent<Animator>().SetTrigger("Jump");
            //    gameObject.GetComponent<Animator>().ResetTrigger("idle");
            //}
        }
    }
    //////////////////////////////////////////////////////////////////////////////
    void Corect_flipX_sprite_position()
    {
        Child.transform.position = new Vector3(-100, Child.transform.position.y, Child.transform.position.z);
    }
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
    void Corect_rotatio()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
    }
    //////////////////////////////////////////////////////////////////////////////
    void CorectROT()
    {
        if (RandL && transform.rotation.y!=0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (!RandL && transform.rotation.y != -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);        
        }
      
    }
    void Jupm()
    {
        
        if (CnInputManager.GetButtonUp("Jump") && isJump)
        {
            gameG.ResetTrigger("idle");
            gameG.SetTrigger("Jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            ImisJump = true;
        }
    }
    //////////////////////////////////////////////////////////////////////////////

   
    // Update is called once per frame
    void FixedUpdate()
    {
        HPControl();
            Move();                 
    }   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {

            gameObject.GetComponent<Animator>().SetTrigger("idle");
            gameObject.GetComponent<Animator>().ResetTrigger("Jump");

            ImisJump = false;
            isJump = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground"&& ImisJump)
        {

            gameObject.GetComponent<Animator>().SetTrigger("Jump");
            isJump = false;
         
        }
        else if (other.tag == "Ground" && !ImisJump)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Down");
            isJump = false;
        }
    }


}

