using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
public class MenuOpen : MonoBehaviour {
    GameObject menuOnGame;
    GameObject playerGui;

    // Use this for initialization
    void Start()
    {
        playerGui = GameObject.FindGameObjectWithTag("PlayerGui");
        menuOnGame = GameObject.FindGameObjectWithTag("MenuOnGame");
        playerGui.SetActive(false);
    }
    void OpenMenu()
    {
        playerGui.SetActive(true);
        menuOnGame.SetActive(false);
    }
    // Update is called once per frames
    void Update()
    {

        if (CnInputManager.GetButtonUp("MenuClose"))
        {
            OpenMenu();
        }
        if (CnInputManager.GetButtonUp("Exit"))
        {
            Application.Quit();
            Debug.Log("quit");
        }
        if (CnInputManager.GetButtonUp("New Game"))
        {
            Debug.Log("New game");
        }
    }
}
