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
        if (Application.platform == RuntimePlatform.Android|| Application.platform==RuntimePlatform.WindowsPlayer||Application.platform == RuntimePlatform.WindowsEditor)

        {
            Debug.Log("set platform");
            if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
            {
                if (menuOnGame.active==true)
                {
                    SetDisActiveMenu();
                    playerGui.SetActive(true);;
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
