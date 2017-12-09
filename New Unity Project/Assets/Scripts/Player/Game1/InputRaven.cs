using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CnControls;
using System.Diagnostics;

[RequireComponent(typeof(MoweRaven))]
public class InputRaven : Unit {

    

    private MoweRaven c_movement =null;
    private bool isJumping=false;
    private bool isRun = false;
    private bool isAttact = false;

    private bool isActive = false;

    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;

    private bool isDoubleCR = false;
    private bool isDoubleCL = false;

    public bool Activ = true;
    float currentTime = 0;  
   float lastClickTime = 0;
   float clickTime = 0.2F;
  
    void Awake()
    {
        //References
        c_movement = GetComponent<MoweRaven>();
    }

   

    void Update()
    {
        if (Activ)
        {
            //If he is not jumping...
            if (!isJumping)
            {
                //See if button is pressed...
                isJumping = CnInputManager.GetButtonUp("Jump");
            }
            if (!isRun)
            {
                //See if button is pressed...
                isRun = CnInputManager.GetButton("Run");
            }
            if (!isAttact)
            {
                //See if button is pressed...
                isAttact = CnInputManager.GetButton("Attack");
            }

            if(!isUp)
            {
               
            }
            if (!isDown)
            {

            }

            if (!isLeft && !isRight)
            {
                isLeft = CnInputManager.GetButton("LeftButton");
            }
            if (!isRight && !isLeft)
            {
                isRight = CnInputManager.GetButton("RightButton");
            }



            if (!isDoubleCL)
            {
              
                if (CnInputManager.GetButtonDown("LeftButton"))
                {
                    isDoubleCR = false;
                    currentTime = Time.time;
                    if ((currentTime - lastClickTime) < clickTime)
                    {
                        isDoubleCL = true;
                    }
                    lastClickTime = currentTime;
                }
            }
            if (CnInputManager.GetButtonUp("LeftButton") && isDoubleCL)
            {
                isDoubleCL = false;
            }
         
            if (!isDoubleCR)
            {
               
                if (CnInputManager.GetButtonDown("RightButton"))
                {
                    isDoubleCL = false;
                    currentTime = Time.time;
                    if ((currentTime - lastClickTime) < clickTime)
                    {
                        isDoubleCR = true;
                    }
                    lastClickTime = currentTime;
                }
            }
            if (CnInputManager.GetButtonUp("RightButton") && isDoubleCR)
            {
                isDoubleCR = false;
            }

        }
    }

    private void FixedUpdate()
    {
        if (Activ)
        {
            //Get horizontal axis
            //float horizontal=0;// = CnInputManager.GetAxis("Horizontal");         

            //Call movement function in PlayerMovement
            c_movement.Move(isLeft,isRight,isDoubleCR,isDoubleCL, isJumping, isRun, isAttact);
            //Reset
            isJumping = false;
            isRun = false;
            isAttact = false;

            isUp = false;
            isDown = false;
            isLeft = false;
            isRight = false;
            
        }
        else
        {
            c_movement.Follow();
        }
    }

    public virtual void FollowMod()
    {
        Activ = !Activ;
    }

    public virtual void FollowModOn()
    {
        Activ = false;
    }

    public virtual void FollowModOff()
    {
        Activ = true;
    }
}
