using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float lifeTime;
    public static float svelocity = 10;
    Rigidbody2D thisRigid;


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
        if(col.gameObject.tag == "Enemy")
        {
            //transform.parent.localScale.Set(transform.parent.localScale.x / col.transform.lossyScale.x, transform.parent.localScale.y / col.transform.lossyScale.y, transform.parent.localScale.z / col.transform.lossyScale.z);
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            transform.parent = col.transform;
        }
        else
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            //thisRigid.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        

        //Destroy the shuriken's rigidbody2D and collider2D

    }
}
