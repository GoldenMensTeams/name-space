using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour {
    GameObject playerGui;
    GameObject menuOnGame;
    // Use this for initialization
    void Start () {
        playerGui = GameObject.FindGameObjectWithTag("PlayerGui");
        menuOnGame = GameObject.FindGameObjectWithTag("MenuOnGame");
        menuOnGame.SetActive(false);
    }
	public void SetGuiDisActive()
    {
        playerGui.SetActive(false);
    }
    public void SetGuiActive()
    {
        playerGui.SetActive(true);
    }
    // Update is called once per frame
    void AndroidBackButton()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
            {
                if (playerGui.active == true)
                {
                    SetGuiDisActive();
                    menuOnGame.SetActive(true);
                }
                else
                {
                    SetGuiActive();
                    menuOnGame.SetActive(false);

                }
            }
        }
    }
    void Update () {
        AndroidBackButton();

    }
}
