using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_1 : MonoBehaviour {


    public float HP = 5f;
    public float maxHP=5f;
    public float Attack = 0.1f;

    private bool agresiv;
    private bool patrul;
    private bool serch;

    public Image UIHP;
    public Image UIHP1;

    // Use this for initialization
    void Start () {
        agresiv = false;
        patrul = true;
        serch = false;
    }
	
	// Update is called once per frame
    void Move()
    {
        if(patrul)
        {
            Patrul();
        }
    }
    void Agresiv()
    {

    }
    void Patrul()
    {

    }
    void Serch()
    {

    }
    void ChecPleayr()
    {

    }
	void FixedUpdate () {
        UIHP.fillAmount = HP / 5;
       
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
          other.GetComponent<ControlPle>().Damag(Attack);        
        }
      
    }
    private void OnGUI()
    {
       // UIHP.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
       // UIHP1.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);

        Vector3 posScr = Camera.main.WorldToScreenPoint(gameObject.transform.position);
       
    }
}
