using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health;
    public static bool seesPlayer;
    public static bool inAttackRange;
    private Animator anim;
    public float speed = 5;
    public float distance;
    public int state; // 0 = idle; 1 = atk; 2 = walk; 3 = followPlayer;
    public RaycastHit2D groundInfo;
    public RaycastHit2D wallInfo;
    public EnemyMovement enemyMovement;
    public EnemyIdleMovement idleMovement;
    public EnemyFollowMovement followMovement;
    public EnemyAttackMovement attackMovement;

    private bool movingRight = true;
    [SerializeField] private LayerMask m_CollideWith;

    public Transform groundDetection;

    private AudioSource SoundSource;
    public AudioClip[] StepSoundsEnemy;
    private int soundIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        idleMovement = GetComponent<EnemyIdleMovement>();
        followMovement = GetComponent<EnemyFollowMovement>();
        attackMovement = GetComponent<EnemyAttackMovement>();


        anim = GetComponent<Animator>();
        SoundSource = GetComponent<AudioSource>();
        state = 2;
        seesPlayer = false;
    }

    void Update()
    {

        Debug.Log("isIdle: " + anim.GetBool("isIdle"));
        Debug.Log("state: " + state);

        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, m_CollideWith);
        wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 0, m_CollideWith);
        //if idle
        if (state == 0)
            {
                // while (seesPlayer && no ledge) go to follow state
                if (seesPlayer && groundInfo.collider == true)
                {
                    state = 3;
                    anim.SetBool("isFollowing", true);
                    anim.SetBool("isIdle", false);
                    //when in atk range, change state to == 1
                }
                //if the player is not in sight of the enemy, have enemy patrol
                else if (!seesPlayer)
                {
                    anim.SetBool("isFollowing", false);
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isPatrolling", true);
                    state = 2;
                }
            }

        // TO DO: if atk 
        else if (state == 1)
        {
            //if player in attack range, attack player
            if (inAttackRange)
            {
                anim.SetBool("isAttacking", true);
                state = 1;
            }
            //if player not in attack range, switch to follow if seesPlayer == true or patrol if !seesPlayer
            else if (!inAttackRange && seesPlayer)
            {
                anim.SetBool("isFollowing", true);
                anim.SetBool("isAttacking", false);
                state = 3;
            }
            else
            {
                anim.SetBool("isPatrolling", true);
                anim.SetBool("isAttacking", false);
                state = 2;
            }
        }

        // if patrol
        else if (state == 2)
        {
            enemyMovement.canWalk = true;
            anim.SetBool("isPatrolling", true);
            // if the enemy sees the player while patrolling, change to followPlayer state
            if (seesPlayer)
            {
                Debug.Log("i see u fox dude");
                enemyMovement.canWalk = false;
                anim.SetBool("isPatrolling", false);
                anim.SetBool("isFollowing", true);
                state = 3;
            }

        }

        // if follow player
        else if (state == 3)
        {
             anim.SetBool("isFollowing", true);
             followMovement.follow();
            

            if (seesPlayer && wallInfo.collider == true)
            {
                seesPlayer = false;
                anim.SetBool("isFollowing", false);
                anim.SetBool("isPatrolling", true);
                state = 2;
            }

            //if enemy detects a ledge while player in sight, switch to idle state, rather than turn around and keep walking in opposite direction
            if (seesPlayer && groundInfo.collider == false)
            {
                anim.SetBool("seesLedge", true);
                anim.SetBool("isFollowing", false);
                state = 0;
            }

            // TO DO: if player in attack range, switch state to attack
            if (inAttackRange)
            {
                anim.SetBool("isFollowing", false);
                anim.SetBool("isAttacking", true);
                state = 1;

            }
            if (!seesPlayer)
            {
                anim.SetBool("isFollowing", false);
                anim.SetBool("isPatrolling", true);
                state = 2;
            }
        }

    }

    // Plays Sounds for footsteps
    void stepEnemy()
    {
        SoundSource.clip = StepSoundsEnemy[soundIndex];
        SoundSource.Play();

        if (soundIndex == 0)
        {
            soundIndex++;
        }
        else
        {
            soundIndex = 0;
        }
    }
}
