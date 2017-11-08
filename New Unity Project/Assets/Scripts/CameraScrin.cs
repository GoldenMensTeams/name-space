using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrin : MonoBehaviour {

    public GameObject pl;

    private void Start()
    {
        
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(pl.transform.position.x, pl.transform.position.y, -10f);

	}
}
