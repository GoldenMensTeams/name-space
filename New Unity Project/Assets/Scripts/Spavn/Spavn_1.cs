using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spavn_1 : MonoBehaviour {

   

    private List<GameObject> enemys;
    public GameObject prefab;
    public float timer=5f;
    public float stay_timer = 5f;
    // Use this for initialization
    void Start () {
        enemys = new List<GameObject>();
       
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
	// Update is called once per frame
	void Update () {

      
        if (enemys.Count < 5)
        {
               
                if(Times())
                enemys.Add(Instantiate(prefab, transform.position, Quaternion.identity));
            
        }
        for (int c =0; c<enemys.Count;c++)
        {

            if (enemys[c] == null)
            {
                enemys.Remove(enemys[c]);
                c = 0;
            }

        }
	}
}
