using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject MessagePanelPlastic;
    public GameObject MessagePanelAtomCanister;
    public GameObject MessagePanelTrump;



    public void Start()
    {
        showMenuPanel();
    }

    void OnEnable()
    {
        EventManager.StartListening("showMenuPanel", showMenuPanel);
        EventManager.StartListening("showMessagePanelPlastic", showMessagePanelPlastic);
        EventManager.StartListening("showMessagePanelAtomCanister", showMessagePanelAtomCanister);
        EventManager.StartListening("showMessagePanelTrump", showMessagePanelTrump);
    }

    void OnDisable()
    {
        EventManager.StopListening("showMenuPanel", showMenuPanel);
        EventManager.StopListening("showMessagePanelPlastic", showMessagePanelPlastic);
        EventManager.StopListening("showMessagePanelAtomCanister", showMessagePanelAtomCanister);
        EventManager.StopListening("showMessagePanelTrump", showMessagePanelTrump);
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
