using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject MessagePanelPlastic;
    public GameObject MessagePanelAtomCanister;
    public GameObject MessagePanelTrump;



    public void Start()
    {
        showMenuPanel();
    }





    public void showMenuPanel()
    {
        menuPanel.SetActive(true);
        MessagePanelPlastic.SetActive(false);
        MessagePanelAtomCanister.SetActive(false);
        MessagePanelTrump.SetActive(false);

    }

    public void showMessagePanelPlastic()
    {
        menuPanel.SetActive(false);
        MessagePanelPlastic.SetActive(true);
        MessagePanelAtomCanister.SetActive(false);
        MessagePanelTrump.SetActive(false);
    }

    public void showMessagePanelAtomCanister()
    {
        menuPanel.SetActive(false);
        MessagePanelPlastic.SetActive(false);
        MessagePanelAtomCanister.SetActive(true);
        MessagePanelTrump.SetActive(false);
    }

    public void showMessagePanelTrump()
    {
        menuPanel.SetActive(false);
        MessagePanelPlastic.SetActive(false);
        MessagePanelAtomCanister.SetActive(false);
        MessagePanelTrump.SetActive(true);
    }
}
