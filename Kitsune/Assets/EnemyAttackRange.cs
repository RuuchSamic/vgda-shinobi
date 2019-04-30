using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{ 
    public Transform attackRangeDetection;
    [SerializeField] private LayerMask m_CollideWithAtkRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D playerInfo = Physics2D.Raycast(attackRangeDetection.position, Vector2.right, 0, m_CollideWithAtkRange);

        if (playerInfo.collider == true)
        {
            Enemy.inAttackRange = true;
            Debug.Log("im gonna atk u");

        }
        else
        {
            Debug.Log("i can't atk u");
        }

    }

}
