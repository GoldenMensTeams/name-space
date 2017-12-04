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
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
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
