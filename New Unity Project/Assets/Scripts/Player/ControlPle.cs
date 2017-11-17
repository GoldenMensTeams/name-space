using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;


public class ControlPle : MonoBehaviour
{
    Vector3 position;
    public float speed = 5f;
    private float memor_speed;
    public float run;
    public float Jump = 5f;
    private bool isJump = true;
    private float MoveX;
    private bool RandL = true;
    private Animator gameG;

    public float HELS = 1f;
    public float Enerjy = 1f;
    public float Stamina = 1f;

    // Use this for initialization
    void Start()
    {
        memor_speed = speed;
        gameG = GetComponent<Animator>();
    }

    void Move()
    {
        CorectROT();

        position = new Vector3(CnInputManager.GetAxis("Horizontal"), 0f, 0f);

        Debug.Log(position.z);

        if (position.x > 0)
        {
            if(CnInputManager.GetButton("Run"))
            {
                speed = run;             
            }
            else {             
                speed = memor_speed;             
            }

            gameG.SetFloat("MoveX", position.x, 0.1f, Time.deltaTime);
            RandL = true;
            gameG.SetBool("RandL", RandL);
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
            RandL = false;
            gameG.SetBool("RandL", RandL);
        }
        else if (position.x == 0)
        {
            gameG.SetFloat("MoveX", position.x, 0.1f, Time.deltaTime);
        }

        if (CnInputManager.GetButtonUp("Jump") && isJump)
        {
            gameG.ResetTrigger("idle");
            gameG.SetTrigger("Jump");           
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Jump), ForceMode2D.Impulse);
        }


    }

    void Attack()
    {
        if (CnInputManager.GetButtonUp("Attack"))
        {

            CorectRandL();
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
    void CorectRandL()
    {
        if (RandL)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    
    }

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
        Debug.Log("is "+transform.rotation.y);
        Debug.Log("is " + RandL);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //тут изменить логику, вместо isJupm
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

        Debug.Log(position.z);
        transform.position += position * Time.deltaTime * speed;

        if (isJump)
        {
            Move();
            Attack();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {

            gameObject.GetComponent<Animator>().SetTrigger("idle");
            gameObject.GetComponent<Animator>().ResetTrigger("Jump");


            isJump = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {

            gameObject.GetComponent<Animator>().SetTrigger("Jump");
            isJump = false;
        }
    }


}

