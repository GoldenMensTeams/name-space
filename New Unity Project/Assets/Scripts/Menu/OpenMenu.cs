using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {

    GameObject menuOnGame;
    GameObject playerGui;

    // Use this for initialization
    private void Awake()
    {
        menuOnGame = GameObject.FindGameObjectWithTag("MenuOnGame");
        playerGui = GameObject.FindGameObjectWithTag("PlayerGui");
       
    }
    void Start () {
        
    }
	
    public void SetActiveMenu()
    {
        menuOnGame.SetActive(true);
        Stop.Pause(true);
    }
    public void SetDisActiveMenu()
    {
        menuOnGame.SetActive(false);
        Stop.Pause(false);
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
                    playerGui.SetActive(true);
                    Stop.Pause(false);
                }
                else
                {
                    SetActiveMenu();
                    playerGui.SetActive(false);
                    Stop.Pause(true);
                }
            }
        }
    }
    void Update()
    {
        AndroidBackButton();
      
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Debug.Log("Pos coord: ("+mousePos.x+","+mousePos.y+")");
    }
}
