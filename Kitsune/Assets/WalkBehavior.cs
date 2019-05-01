using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehavior : StateMachineBehaviour
    {

    public GameObject enemy;
    public float enemySpeed;
    public Transform groundDetection;
    public RaycastHit2D groundInfo;
    public RaycastHit2D wallInfo;
    public float distance;
    [SerializeField] private LayerMask m_CollideWith;
    private bool movingRight = true;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, m_CollideWith);
        wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 0, m_CollideWith);
        enemy.transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);

        Debug.DrawRay(groundDetection.position, Vector2.right, Color.red, distance);

        if (groundInfo.collider == false || wallInfo.collider == true)
        {
            if (movingRight == true)
            {
                enemy.transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {

                enemy.transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;

            }


        }
    }
}
