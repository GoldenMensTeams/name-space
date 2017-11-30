using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    public Unit Pl;
    

    public void Resets()
    {
        Pl.HELS = Pl.maxHELS;
        Pl.gameObject.SetActive(true);

       
    }
    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            Resets();
        }
    }
}
