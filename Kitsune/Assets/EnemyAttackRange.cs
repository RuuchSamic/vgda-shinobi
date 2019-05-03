using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{ 
    public Transform attackRangeDetection;
    [SerializeField] private LayerMask m_CollideWithAtkRange;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D playerInfo = Physics2D.Raycast(attackRangeDetection.position, Vector2.right, 0, m_CollideWithAtkRange);

        if (playerInfo.collider == true)
        {
            Enemy.inAttackRange = true;
            anim.SetBool("animInAtkRange", true);

            Debug.Log("im gonna atk u");

        }
        else
        {
            Enemy.inAttackRange = false;
            anim.SetBool("animInAtkRange", false);
            Debug.Log("i can't atk u");
        }

    }

}
