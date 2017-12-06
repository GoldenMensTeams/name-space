using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonousTrap : BaseTrap
{
    public float damag;
    public float healse = 1f;
    private bool time = false;
    public float timer = 2f;
    public float stay_timer = 2f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (healse <= 0)
        {
            Destroy(gameObject);
        }

        if (Times())
            time = true;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up, 0.4F);
        foreach (Collider2D c in colliders)
            if (c.tag == "Enemy")
            {
                if (time)
                {
                    healse -= damag;
                    c.GetComponent<Unit>().ReciveDamage(damag);
                    time = false;
                }
            }
    }
    bool Times()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return false;
        }
        else if (timer < 0)
        {
            timer = stay_timer;
            return true;
        }
        return false;
    }
}
