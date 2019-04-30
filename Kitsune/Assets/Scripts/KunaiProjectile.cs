using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiProjectile : MonoBehaviour
{
    public float lifeTime;
    public static float svelocity = 50;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
    //private void Update()
    //{
    //    transform.Translate(Vector2.up * speed * Time.deltaTime);
    //}

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
