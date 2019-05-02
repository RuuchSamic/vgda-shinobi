using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionScript : MonoBehaviour
{

    public Enemy enemy;
    public RaycastHit2D playerInfo;
    public Transform enemyDetection;
    [SerializeField] private LayerMask d_CollideWith;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInfo = Physics2D.Raycast(enemyDetection.position, Vector2.right, 5, d_CollideWith);
        if (playerInfo == true)
        {
            Enemy.seesPlayer = true;
            Debug.Log("i see u");
        }
        else
        {
            Enemy.seesPlayer = false;
            Debug.Log("whered u go");
        }
    }

    //private void OnTriggerEnter2D(Collider2D player)
    //{
    //    if(player.gameObject.tag == "Player") 
    //    {
    //        Enemy.seesPlayer = true;

    //        Debug.Log("i see u");
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D player)
    //{
    //    if (player.gameObject.tag == "Player")
    //    {
    //        Enemy.seesPlayer = false;
    //        Debug.Log("whered u go");
    //    }
    //}
}
