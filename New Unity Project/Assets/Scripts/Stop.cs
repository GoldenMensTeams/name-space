using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour {

    private bool paused = false;

    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
           
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
