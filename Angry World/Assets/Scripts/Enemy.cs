using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float destroyVelocity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(collision.relativeVelocity.x) >= destroyVelocity || Mathf.Abs(collision.relativeVelocity.y) >= destroyVelocity)
        {
            Hitted();
        }
    }
    private void Hitted()
    {
        EventManager.TriggerEvent("EnemyHitted");
        Destroy(this.gameObject);
    }
}
