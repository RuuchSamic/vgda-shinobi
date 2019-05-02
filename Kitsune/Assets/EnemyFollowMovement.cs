using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowMovement : MonoBehaviour
{
    public Enemy enemy;
    private Transform playerPos;
    public float speed;
    public Animator anim;
    public RaycastHit2D vectorFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        speed = enemy.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isFollowing")) 
        {
            follow();
            Debug.Log("ENEMY SPEED WHILE FOLLOWING:" + speed);
        }
    }

    public void follow()
    {

        //TO DO: add vector that is able to tell if player is behind enemy or in front of it, and flips bear accordingly? 
        //OR: change circle collider to a ray
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, playerPos.position, 0.1f);

    }
}
