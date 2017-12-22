using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrin : MonoBehaviour {

    public GameObject pl1;
    public GameObject pl2;
    public GameObject mainCam;
    public List<GameObject>Controls;
    Camera myCam;
    public bool isFerst = true;
    public bool isMin = false;
    public float height_camera;
    float start;
    public float distants;
    public float Withs;
    public virtual void FollowMod()
    {
        isFerst = !isFerst;
    }
    public virtual void IsMaxMod()
    {
        isMin = !isMin;

        if(isMin)
        {

            myCam.orthographicSize = distants;
            foreach (GameObject e in Controls)
                e.active = false;
        }
        else
        {
            myCam.orthographicSize = start;          
            foreach (GameObject e in Controls)
                e.active = true;

        }
    }

    private void Start()
    {
       
        myCam =GetComponent<Camera>();
        start = myCam.orthographicSize;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
    // Update is called once per frame
    void Update () {

        if (isMin)
        {



            if (isFerst)
                transform.position = new Vector3(pl1.transform.position.x, pl1.transform.position.y + Withs, transform.position.z);
            else
                transform.position = new Vector3(pl2.transform.position.x, pl2.transform.position.y + Withs, transform.position.z);

           
        }
        else
        {
           
            if (isFerst)
                transform.position = new Vector3(pl1.transform.position.x, pl1.transform.position.y + height_camera, transform.position.z);
            else
                transform.position = new Vector3(pl2.transform.position.x, pl2.transform.position.y + height_camera, transform.position.z);
        }
      
       
    }
}
