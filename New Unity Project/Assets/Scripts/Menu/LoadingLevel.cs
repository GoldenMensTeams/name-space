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
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                Application.Quit();
            }
        }
    }
}
