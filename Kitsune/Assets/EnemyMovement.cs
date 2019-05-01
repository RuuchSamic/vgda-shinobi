using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool canWalk;
    public GameObject enemy;
    public float enemySpeed;
    public Transform groundDetection;
    public RaycastHit2D groundInfo;
    public RaycastHit2D wallInfo;
    public float distance;
    [SerializeField] private LayerMask m_CollideWith;
    private bool movingRight = true;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1, m_CollideWith);

        Debug.Log("i can walk");

        Debug.DrawRay(groundDetection.position, Vector2.right, Color.red, distance);

        wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 0, m_CollideWith);
        if (anim.GetBool("isPatrolling"))
        {
            walk();

        }
    }

    public void walk()
    {
        enemy.transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);

        if (groundInfo.collider == false || wallInfo.collider == true)
        {
            if (groundInfo.collider == false)
            {
                Debug.Log("i detected a ledge");
            }
            if (wallInfo.collider == true)
            {
                Debug.Log("i detected a wall");
            }

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
