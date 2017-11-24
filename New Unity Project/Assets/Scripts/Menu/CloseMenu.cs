using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour {
    GameObject playerGui;
    // Use this for initialization
    void Start () {
        playerGui = GameObject.FindGameObjectWithTag("PlayerGui");
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
	void Update () {
		
	}
}
