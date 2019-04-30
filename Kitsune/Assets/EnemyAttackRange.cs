using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
 
    public Transform playerPos;
    [SerializeField] private LayerMask m_CollideWithAtkRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D playerInfo = Physics2D.Raycast(playerPos.position, Vector2.right, 0, m_CollideWithAtkRange);

    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Enemy.inAttackRange = true;

            Debug.Log("im gonna atk u);
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Enemy.inAttackRange = false;
            Debug.Log("i cant atk u");
        }
    }
}
