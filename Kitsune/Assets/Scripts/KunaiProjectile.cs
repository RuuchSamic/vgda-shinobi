using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiProjectile : MonoBehaviour
{
    public float lifeTime;
    public static float svelocity = 50;
    private Renderer spriteImage;
    private BoxCollider2D colliderObj;
    private TrailRenderer myTail;
    private void Start()
    {
        myTail = GetComponent<TrailRenderer>();
        spriteImage = GetComponent<Renderer>();
        colliderObj = GetComponent<BoxCollider2D>();
        Invoke("DestroyProjectile", lifeTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            //DestroyProjectile();
            spriteImage.enabled = false;
            colliderObj.enabled = false;
            Destroy(myTail);
            Destroy(gameObject, 1.0f);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
