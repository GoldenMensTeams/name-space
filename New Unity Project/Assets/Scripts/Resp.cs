using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resp : MonoBehaviour {

    public GameObject resp;
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            other.transform.position = resp.transform.position;
        }
    }
	// Update is called once per frame
	
}
