using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMenuScript : MonoBehaviour {

    GameObject settingsCanvas;
    GameObject aboutUsCanvas;
    GameObject buttonsCanvas;
    GameObject exitCanvas;

    public string LevelOnBackButton;
    // Use this for initialization
    private void Awake()
    {
        buttonsCanvas = GameObject.FindGameObjectWithTag("GeneralMenuButtons");
        settingsCanvas = GameObject.FindGameObjectWithTag("GeneralMenuSettings");
        aboutUsCanvas = GameObject.FindGameObjectWithTag("GeneralMenuAboutUs");
        exitCanvas = GameObject.FindGameObjectWithTag("GeneralMenuExit");
    }
    void Start () {
        InitializedGeneralMenu();

    }
    private void InitializedGeneralMenu()
    {
        settingsCanvas.SetActive(false);
        aboutUsCanvas.SetActive(false);
        exitCanvas.SetActive(false);
    }
    public void InitializedSettings(bool init)
    {
        settingsCanvas.SetActive(init);
        ReverseBool(ref init);
        buttonsCanvas.SetActive(init);

    }
    public void InitializedAboutUs(bool init)
    {
        aboutUsCanvas.SetActive(init);
        ReverseBool(ref init);
        buttonsCanvas.SetActive(init);

    }
    public void InitializedExit(bool init)
    {
        exitCanvas.SetActive(init);
        ReverseBool(ref init);
        buttonsCanvas.SetActive(init);

    }
    private void ReverseBool(ref bool b)
    {
        if (b == true)
        {
            b = false;
        }
        else
        {
            b = true;
        }
    }

    void AndroidBackButton()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)

        {
            Debug.Log("set platform");
            if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
            {
                if (settingsCanvas.active == true)
                {
                    InitializedSettings(false);
                }
                else if (aboutUsCanvas.active == true)
                {
                    
                }
                else
                {
                    LoadingLevel.LoadLevel(LevelOnBackButton);
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        AndroidBackButton();
    }
}
