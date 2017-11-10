using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    public GameObject pl;
    private float x;
    private float y;
    // Use this for initialization
    void Start () {
		x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;


    }

    // Update is called once per frame
    void Update () {
		
	}
    void FixedUpdate()
    {
       
        transform.position = new Vector3(x+(x-pl.transform.position.x)/5,y+(y- pl.transform.position.y-20)/5, +10f);

      
    }
    }
