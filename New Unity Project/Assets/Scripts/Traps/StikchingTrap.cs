using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StikchingTrap : BaseTrap
{

    public float damag;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up , 0.4F);
        foreach (Collider2D c in colliders)
            if (c.tag == "Player1")
            {
                c.GetComponent<Unit>().ReciveDamage(damag);
            }
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
      
    }

}
