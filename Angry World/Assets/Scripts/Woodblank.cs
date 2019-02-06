using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodblank : MonoBehaviour {

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
        Destroy(this.gameObject);
    }
}
