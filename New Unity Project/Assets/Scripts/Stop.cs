using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop  {


    static public void Pause(bool ispause)
    {
        if (ispause)
        {
            Time.timeScale = 0;
            Debug.Log("1");
        }
        else
        {
            Debug.Log("2");
            Time.timeScale = 1;
        }
    }
    
}
