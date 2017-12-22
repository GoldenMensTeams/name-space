using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CnControls;
using System.Diagnostics;

[RequireComponent(typeof(MoweHedgehog))]
public class InputHedgehog : Unit {

    private MoweHedgehog c_movement =null;
    private bool isJumping=false;
    private bool isRun = false;
    private bool isUsed = false;

    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;

    private bool isDoubleCR = false;
    private bool isDoubleCL = false;

    public bool stop = true;
    public bool Activ = true;
    float currentTime = 0;  
   float lastClickTime = 0;
   float clickTime = 0.2F;
  
  
   ///void KeyUp(ref bool clic)   1
    //{
    //    time = Stopwatch.GetTimestamp();
    //    clic = false;
    //}
    //void KeyDown(ref bool clic)
    //{
    //    if (time - Stopwatch.GetTimestamp() <= 100)
    //        clic = true;
    //}

    void Awake()
    {
        //References
        c_movement = GetComponent<MoweHedgehog>();
    }

    public void IsStop()
    {
        stop = !stop;
    }

    void Update()
    {
        if (stop)
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
            if (!isUsed)
            {
                    //See if button is pressed...
                    isUsed = CnInputManager.GetButton("Used");
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
            c_movement.Move(isLeft,isRight,isDoubleCR,isDoubleCL, isJumping, isRun, isUsed);
            //Reset
            isJumping = false;
            isRun = false;
            isUsed = false;

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

