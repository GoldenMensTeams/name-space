using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrin : MonoBehaviour {

    public GameObject pl1;
    public GameObject pl2;
    public bool isFerst = true;
    public float height_camera;
    public virtual void FollowMod()
    {
        isFerst = !isFerst;
    }
  

    private void Start()
    {
       
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
    // Update is called once per frame
    void Update () {
        

        if(isFerst)
        transform.position = new Vector3(pl1.transform.position.x, pl1.transform.position.y+ height_camera, transform.position.z);
        else
            transform.position = new Vector3(pl2.transform.position.x, pl2.transform.position.y + height_camera, transform.position.z);
    }
}
