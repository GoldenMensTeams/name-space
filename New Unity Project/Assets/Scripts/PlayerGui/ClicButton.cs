using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class ClicButton : MonoBehaviour {

    private float H;
    private float W;
    public float size_del;
 
	// Use this for initialization
	void Start () {
        H = transform.localScale.y;
        W = transform.localScale.x;
    }
   


	// Update is called once per frame
	void Update () {

        if (CnInputManager.GetButtonDown(gameObject.name))
            transform.localScale = new Vector3(transform.localScale.x - size_del, transform.localScale.y - size_del);
        if (CnInputManager.GetButtonUp(gameObject.name))
            transform.localScale = new Vector3(transform.localScale.x + size_del, transform.localScale.y + size_del);
    }
}
