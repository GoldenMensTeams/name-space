using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_1 : MonoBehaviour {


    public float HP = 5f;
    public float maxHP;
    public Image UIHP;
    public Image UIHP1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        UIHP.fillAmount = HP / 5;
        UIHP.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y+2f, transform.position.z);
        UIHP1.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        if (HP<=0)
        {
            gameObject.SetActive(false);
        }
	}
    public void Damag(float damag)
    {
        HP -= damag;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
          other.GetComponent<ControlPle>().Damag(0.1f);        
        }
      
    }
}
