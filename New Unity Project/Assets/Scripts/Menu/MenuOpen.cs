using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class MenuClose : MonoBehaviour {
    GameObject menuOnGame;
    GameObject playerGui;
    bool isFirstSetup = true;
    // Use this for initialization
    void Start () {
        playerGui = GameObject.FindGameObjectWithTag("PlayerGui");
        menuOnGame = GameObject.FindGameObjectWithTag("MenuOnGame");
        menuOnGame.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (CnInputManager.GetButtonUp("MenuOpen"))
        {
            OpenMenu();
        }
    }
    void OpenMenu()
    {
        menuOnGame.SetActive(true);
        if (!isFirstSetup)
        {
            playerGui.SetActive(false);
        }
        isFirstSetup = false;
    }
}
