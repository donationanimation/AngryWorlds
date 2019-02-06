using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject QuitButton;
    public GameObject menuPanel;
    public GameObject MessagePanelPlastic;
    public GameObject MessagePanelAtomCanister;
    public GameObject MessagePanelTrump;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playGame()
    {
        menuPanel.SetActive(false);
        MessagePanelPlastic.SetActive(false);
        MessagePanelAtomCanister.SetActive(false);
        MessagePanelTrump.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
