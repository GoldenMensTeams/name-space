using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingLevel : MonoBehaviour {

    // Use this for initialization
    public string Level;
	void Start () {
		
	}
	public void LoadLevel()
    {
        Application.LoadLevel(Level);
    }
    public static void LoadLevel(string load)
    {
        Application.LoadLevel(load);
    }
	// Update is called once per frame
	void Update () {
        
    }
}
