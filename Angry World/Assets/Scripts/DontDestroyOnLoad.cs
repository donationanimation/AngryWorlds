using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DontDestroyOnLoad : MonoBehaviour
{
    private bool isCreated = false;

    void Awake()
    {
        if (!isCreated)
        {
            DontDestroyOnLoad(this.gameObject);
            isCreated = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnEnable()
    {
        EventManager.StartListening("GameOver", GameOver);
    }

    void OnDisable()
    {
        EventManager.StopListening("GameOver", GameOver);

    }

    void GameOver()
    {
        Destroy(this.gameObject);

    }
}
