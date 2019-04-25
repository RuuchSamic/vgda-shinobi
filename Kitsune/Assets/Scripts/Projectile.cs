using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float lifeTime;
    public static float svelocity = 20;

    public GameObject destroyEffect;

    private void Start()
    { 
        Invoke("DestroyProjectile", lifeTime);
    }
    //private void Update()
    //{
    //   // transform.Translate(Vector2.up * speed * Time.deltaTime);
    //}

    void DestroyProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    bool hit = false;
    float depth = 0.30F;
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

        // move the arrow deep inside the enemy or whatever it sticks to
        //col.transform.Translate(depth * -Vector2.right);
        // Make the arrow a child of the thing it's stuck to
        transform.parent = col.transform;
        //Destroy the arrow's rigidbody2D and collider2D
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<BoxCollider2D>());
    }
}
