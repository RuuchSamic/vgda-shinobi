using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMechanic : MonoBehaviour
{
    public GameObject grappleProjectile;
    Vector3 grapplePosition;
    public bool isGrappled = false;
    public float grappleSpeed;
    public GameObject player;
    

    private void Update()
    {
        if(isGrappled == true)
        {
            float step = grappleSpeed * Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(player.transform.position, grapplePosition, step);
        }
        
        if(player.transform.position == grapplePosition)
        {
            isGrappled = false;
            Destroy(grappleProjectile);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        player = GameObject.FindWithTag("Player");

        if (collision.gameObject.tag != "Player")
        {
            grapplePosition = collision.transform.position;
            isGrappled = true;
            grappleProjectile.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            //Destroy(grappleProjectile);
        }
    }
}
