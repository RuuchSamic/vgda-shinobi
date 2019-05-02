using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleMovement : MonoBehaviour
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
        if (anim.GetBool("isIdle"))
        {
            anim.SetBool("isPatrolling", false);
            idle();
        }
    }

    public void idle()
    {
        Debug.Log("im idling");
    }

}
