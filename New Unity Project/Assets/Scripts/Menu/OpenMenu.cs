using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {

    GameObject menuOnGame;
    GameObject playerGui;

    // Use this for initialization
    void Start () {
        menuOnGame = GameObject.FindGameObjectWithTag("MenuOnGame");
        menuOnGame.SetActive(false);
    }
	
    public void SetActiveMenu()
    {
        menuOnGame.SetActive(true);
    }
    public void SetDisActiveMenu()
    {
        menuOnGame.SetActive(false);
    }
	// Update is called once per frame
	void Update ()
    {}
}
