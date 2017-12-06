using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour {

    GameObject acceptCanvas;
    // Use this for initialization
    private void Awake()
    {
        acceptCanvas = GameObject.FindGameObjectWithTag("AcceptCanvas");
    }
    void Start () {
        SetDisActiveAcceptCanvas();
    }
    public void SetActiveAcceptCanvas()
    {
        acceptCanvas.SetActive(true);
    }
    public void SetDisActiveAcceptCanvas()
    {
        acceptCanvas.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    void AndroidBackButton()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)

        {
            Debug.Log("set platform");
            if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
            {
                if (acceptCanvas.active == true)
                {
                    SetDisActiveAcceptCanvas();
                }
                else
                {
                    SetActiveAcceptCanvas();
                }
            }
        }
    }
    // Update is called once per frame
    void Update () {
        AndroidBackButton();
    }
}
