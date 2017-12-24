using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

   public GameObject obj1;

	// Use this for initialization
		
	
    public void GoTo(Collider2D collision)
    {
        collision.transform.position = obj1.transform.position;
    }

  
}
