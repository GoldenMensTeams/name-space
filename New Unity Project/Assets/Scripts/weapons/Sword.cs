using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public float damag;

    public Enemy_1 vrag;
	// Use this for initialization

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            vrag = other.GetComponent<Enemy_1>();
            vrag.Damag(damag);
        }
    }
}
