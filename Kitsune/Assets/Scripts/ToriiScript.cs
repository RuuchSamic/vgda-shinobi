using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToriiScript : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (true)
        {
            Debug.Log("Player has ended the level");
        }
    }
}
