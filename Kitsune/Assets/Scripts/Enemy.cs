using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public KunaiDamageScript kunai;
    public float health;
    public static bool seesPlayer;
    public static bool inAttackRange;
    private Animator anim;
    public float speed = 5;
    public float distance;
    public int state; // 0 = idle; 1 = atk; 2 = walk; 3 = followPlayer;
    public RaycastHit2D groundInfo;
    public RaycastHit2D wallInfo;
    public RaycastHit2D airInfo;
    public EnemyMovement enemyMovement;
    public EnemyIdleMovement idleMovement;
    public EnemyFollowMovement followMovement;
    public EnemyAttackMovement attackMovement;
    private PolygonCollider2D bearCollider;

    private bool movingRight = true;
    [SerializeField] private LayerMask m_CollideWith;

    public Transform groundDetection;
    public Transform InAirCheck;

    private AudioSource SoundSource;
    public AudioClip[] StepSoundsEnemy;
    private int soundIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        bearCollider = GetComponent<PolygonCollider2D>();
        health = 15;
        enemyMovement = GetComponent<EnemyMovement>();
        idleMovement = GetComponent<EnemyIdleMovement>();
        followMovement = GetComponent<EnemyFollowMovement>();
        attackMovement = GetComponent<EnemyAttackMovement>();


        anim = GetComponent<Animator>();
        SoundSource = GetComponent<AudioSource>();
        airInfo = Physics2D.Raycast(InAirCheck.position, Vector2.down, 1, m_CollideWith);
        if (airInfo.collider == false)
        {
            anim.SetBool("inAir", true);
            anim.SetBool("isPatrolling", false);
            state = 0;
        }
        else
        {
            state = 2;
        }
        seesPlayer = false;
    }

    void Update()
    {

        Debug.Log("BEAR'S CURRENT HEALTH: " + health);

        if (health <= 0)
        {
            anim.SetBool("isDying", true);
            anim.SetBool("isIdle", true);
            anim.SetBool("isPatrolling", false);
            state = 0;
            enemyMovement.canWalk = false;
            //killEnemy();
        }

        airInfo = Physics2D.Raycast(InAirCheck.position, Vector2.down, 1, m_CollideWith);

        if (airInfo.collider == false)
        {
            state = 0;
            enemyMovement.canWalk = false;
            anim.SetBool("isIdle", true);
            anim.SetBool("isPatrolling", false);
            anim.SetBool("inAir", true);
        }
        else if (airInfo.collider == true)
        {
            enemyMovement.canWalk = true;
            anim.SetBool("inAir", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isPatrolling", true);
        }

        Debug.Log("isIdle: " + anim.GetBool("isIdle"));
        Debug.Log("state: " + state);

        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, m_CollideWith);
        wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 0, m_CollideWith);
        //if idle
        if (state == 0)
            {

            //if (anim.GetBool("isDying") || health == 0)
            //{
            //    killEnemy();
            //}

            //enemyMovement.canWalk = false;
                if (anim.GetBool("inAir") && health > 0)
            {
                anim.SetBool("isPatrolling", false);
            }
                
                // while (seesPlayer && no ledge) go to follow state
                if (seesPlayer && groundInfo.collider == true && health > 0)
                {
                    state = 3;
                    anim.SetBool("isFollowing", true);
                    anim.SetBool("isIdle", false);
                    //when in atk range, change state to == 1
                }
                if (seesPlayer && groundInfo.collider == false && health > 0)
            {
                anim.SetBool("isFollowing", false);
                anim.SetBool("isIdle", true);
            }
                //if the player is not in sight of the enemy, have enemy patrol
                else if (!seesPlayer && (airInfo.collider == true) && health > 0)
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

            anim.SetBool("isFollowing", false);
            anim.SetBool("isPatrolling", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", true);

            //if player in attack range, attack player
            if (inAttackRange && groundInfo.collider == true)
            {

                //gameObject.tag = "BearAttack";
                Debug.Log("IM ATTACKING RN 1");

                anim.SetBool("isAttacking", true);
                anim.SetBool("isFollowing", false);
                anim.SetBool("isPatrolling", false);
                enemyMovement.canWalk = false;
            }

            if (inAttackRange && groundInfo.collider == false)
            {
                Debug.Log("IM ATTACKING RN 2");

                //gameObject.tag = "BearAttack";

                anim.SetBool("isAttacking", true);
                anim.SetBool("isFollowing", false);
                anim.SetBool("isPatrolling", false);
                enemyMovement.canWalk = false;
            }

            //if player not in attack range, switch to follow if seesPlayer == true or patrol if !seesPlayer
            else if (!inAttackRange && seesPlayer)
            {
                anim.SetBool("isFollowing", true);
                anim.SetBool("isPatrolling", false);
                anim.SetBool("isAttacking", false);
                state = 3;
                Debug.Log("!inAttackRang && seesPlayer");
            }
            else if (inAttackRange && groundInfo.collider == false)
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isFollowing", false);
                anim.SetBool("seesLedge", true);
                anim.SetBool("isPatrolling", false);
                Debug.Log("inAttackRange && groundInfo.collider == false");
            }
            else
            {
                anim.SetBool("isPatrolling", true);
                anim.SetBool("isAttacking", false);
                state = 2;
                Debug.Log("final else");
            }
        }

        // if patrol
        else if (state == 2)
        {
            enemyMovement.canWalk = true;
            anim.SetBool("isPatrolling", true);
            // if the enemy sees the player while patrolling, change to followPlayer state
            if (seesPlayer && groundInfo.collider == true)
            {
                Debug.Log("i see u fox dude");
                enemyMovement.canWalk = false;
                anim.SetBool("isPatrolling", false);
                anim.SetBool("isFollowing", true);
                state = 3;
            }
            else if (seesPlayer && groundInfo.collider == false)
            {
                enemyMovement.canWalk = false;
                anim.SetBool("isPatrolling", false);
                anim.SetBool("isFollowing", false);
                anim.SetBool("isIdle", true);
                state = 0;
            }

        }

        // if follow player
        else if (state == 3)
        {
             anim.SetBool("isFollowing", true);
             followMovement.follow();
            

            if (seesPlayer && wallInfo.collider == true)
            {
                Debug.Log("executing seesPlayer && wallInfo.collder == true block");
                seesPlayer = false;
                anim.SetBool("isFollowing", false);
                anim.SetBool("isPatrolling", true);
                state = 2;
            }

            //if enemy detects a ledge while player in sight, switch to idle state, rather than turn around and keep walking in opposite direction
            if (seesPlayer && groundInfo.collider == false)
            {
                Debug.Log("I see a ledge AND i see the player, so I'm going to idle");
                anim.SetBool("seesLedge", true);
                anim.SetBool("isFollowing", false);
                anim.SetBool("isIdle", true);
                state = 0;
            }

            // TO DO: if player in attack range, switch state to attack
            if (inAttackRange && groundInfo.collider == true)
            {
                Debug.Log("executing seesPlayer && groundInfo.collder == true block");
                anim.SetBool("isFollowing", false);
                anim.SetBool("isAttacking", true);
                state = 1;

            }
            if (!seesPlayer)
            {
                Debug.Log("executing !seesPlayer block");
                anim.SetBool("isFollowing", false);
                anim.SetBool("isPatrolling", true);
                state = 2;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("im touching u");
            anim.SetBool("animInAtkRange", true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Animator otherAnim = other.gameObject.GetComponent<Animator>();
            otherAnim.SetTrigger("PlayerDeath");
            //Destroy(other.gameObject, otherAnim.GetCurrentAnimatorStateInfo(0).length);
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

    public void killEnemy()
    {

        //Destroy(gameObject.GetComponent<SpriteRenderer>());
        anim.SetBool("isPatrolling", false);
        enemyMovement.canWalk = false;
        //gameObject.tag = "DeadEnemy";
        Destroy(gameObject);
        
    }



}
