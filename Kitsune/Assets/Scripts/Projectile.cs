using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float lifeTime;
    public static float svelocity = 10;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    void DestroyProjectile() {
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        Destroy(gameObject);
    }

    bool hit = false;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (!hit)
            {
                ShurikenStick(other);
                hit = true;
            }
        }
    }
    void ShurikenStick(Collision2D col)
    {
        transform.parent = col.transform;

        //Destroy the shuriken's rigidbody2D and collider2D
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<BoxCollider2D>());
    }
}
