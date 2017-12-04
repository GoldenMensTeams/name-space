using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {

    GameObject menuOnGame;
    GameObject playerGui;

    // Use this for initialization
    void Start () {
        menuOnGame = GameObject.FindGameObjectWithTag("MenuOnGame");
        playerGui = GameObject.FindGameObjectWithTag("PlayerGui");
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
    void AndroidBackButton()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                if (menuOnGame.active==true)
                {
                    SetDisActiveMenu();
                    playerGui.SetActive(true);
                }
                else
                {
                    SetActiveMenu();
                    playerGui.SetActive(false);
                }
            }
        }
    }
	void Update ()
    {
        AndroidBackButton();
    }
}
