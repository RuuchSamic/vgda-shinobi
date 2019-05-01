using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMovement : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isAttacking"))
        {
            attack();
        }
    }

    public void attack()
    {
        Debug.Log("im attacking u");
    }


}
