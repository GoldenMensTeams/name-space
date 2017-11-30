using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CnControls;

[RequireComponent(typeof(MowePlayer))]
public class InputPlayer : MonoBehaviour {

    private MowePlayer c_movement=null;
    private bool isJumping=false;
    private bool isRun = false;
    private bool isAttact = false;



    void Awake()
    {
        //References
        c_movement = GetComponent<MowePlayer>();
    }

    void Update()
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
            isAttact = CnInputManager.GetButtonUp("Attack");
        }
    }

    private void FixedUpdate()
    {
        //Get horizontal axis
        float horizontal = CnInputManager.GetAxis("Horizontal");
        //Call movement function in PlayerMovement
        c_movement.Move(horizontal, isJumping, isRun, isAttact);
        //Reset
        isJumping = false;
        isRun = false;
        isAttact = false;
}
}
