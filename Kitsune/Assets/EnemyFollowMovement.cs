using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowMovement : MonoBehaviour
{
    public Enemy enemy;
    private Transform playerPos;
    public float speed;
    public Animator anim;

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
        }
    }

    public void follow()
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, playerPos.position, speed * Time.deltaTime);
    }
}
