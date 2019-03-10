using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerPos;
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerPos = collision.transform;
    }
}
