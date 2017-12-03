using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CnControls;
using System.Diagnostics;

[RequireComponent(typeof(MowePlayer))]
public class InputPlayer : Unit {

    private MowePlayer c_movement=null;
    private bool isJumping=false;
    private bool isRun = false;
    private bool isAttact = false;

    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;

    private bool isDoubleCR = false;
    private bool isDoubleCL = false;

    long time;

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
        c_movement = GetComponent<MowePlayer>();
    }

   

    void Update()
    {
        if (freez)
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
            //if (CnInputManager.GetButtonDown("LeftButton"))
            //{
            //    isDoubleCR = false;
            //    currentTime = Time.time;
            //    if ((currentTime - lastClickTime) < clickTime)
            //    {
            //        isDoubleCL = true;
            //    }
            //    lastClickTime = currentTime;
            //}
            //if (CnInputManager.GetButtonUp("LeftButton") && isDoubleCL)
            //{
            //    isDoubleCL = false;

            //    lastClickTime /= 5;

            //}


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

            //if (CnInputManager.GetButtonDown("RightButton"))
            //{
            //    isDoubleCL = false;
            //    currentTime = Time.time;
            //    if ((currentTime - lastClickTime) < clickTime)
            //    {
            //        isDoubleCR = true;
            //    }
            //    lastClickTime = currentTime;
            //}
            //if (CnInputManager.GetButtonUp("RightButton") && isDoubleCL)
            //{
            //    isDoubleCR = false;

            //    lastClickTime /= 5;


            //}


        }
    }

    private void FixedUpdate()
    {
        if (freez)
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
    }

   
}
