﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public string infoText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Hitted();
        }
    }
    private void Hitted()
    {
        print("hitted");
        EventManager.TriggerEvent("EnemyHitted");
        Destroy(this.gameObject);
    }
}
