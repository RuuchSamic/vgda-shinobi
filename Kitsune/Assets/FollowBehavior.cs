//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FollowBehavior : StateMachineBehaviour
//{

   

//    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
//    }

//    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
//    }

//    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {

//    }

//}
