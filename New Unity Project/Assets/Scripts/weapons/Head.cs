using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
	
    public float damag;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            other.GetComponent<ControlPle>().Damag(damag);          
        }
    }
}
