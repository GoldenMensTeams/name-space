using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSk : MonoBehaviour {

    public GameObject pl;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(pl.transform.position.x, pl.transform.position.y, -10f);

	}
}
