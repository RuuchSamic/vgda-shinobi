using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //TO DO: add booleans for animation states, e.g. anim.setBool("isFollowing", true);?
    public static bool seesPlayer;
    private Animator anim;
    public float speed;
    public float distance;
    public int state; // 0 = idle; 1 = atk; 2 = walk; 3 = followPlayer;

    private bool movingRight = true;
    [SerializeField] private LayerMask m_CollideWith;

    public Transform groundDetection;

    private AudioSource SoundSource;
    public AudioClip[] StepSoundsEnemy;
    private int soundIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        SoundSource = GetComponent<AudioSource>();
        state = 2;
        seesPlayer = false;
    }

    void Update()
    {
        // TO DO: add ray that only detects if player is in close enough range to attack; doesn't collide with anything
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, m_CollideWith);
        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 0, m_CollideWith);

        // if idle
        if (state == 0)
        {
            // while (seesPlayer && no ledge) go to follow state
            if(seesPlayer && groundInfo.collider == true)
            {
                //set state to followPlayer
                //move toward player
                //when in atk range, change state to == 1
                state = 3;
            }
            //if the player is not in sight of the enemy, have enemy patrol
            else if (!seesPlayer)
            {
                state = 2;
            }
        }

        // TO DO: if atk 
        if (state == 1)
        {
            //if player in attack range, attack player
            // if player not in attack range, switch to follow if seesPlayer == true or patrol if !seesPlayer
        }

        // if patrol
        if (state == 2)
        {
            // if the enemy sees the player while patrolling, change to followPlayer state
            if (seesPlayer)
            {
                state = 3;
            }

            transform.Translate(Vector2.right * speed * Time.deltaTime);
            
            Debug.DrawRay(groundDetection.position, Vector2.right, Color.red, distance);

            if (groundInfo.collider == false || wallInfo.collider == true)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {

                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;

                }


            }
        }

        // if follow player
        if (state == 3)
        {
            //TO DO: get player's current transform.position and move toward it

            //if enemy detects a ledge while player in sight, switch to idle state, rather than turn around and keep walking in opposite direction
            if (seesPlayer && groundInfo.collider == false)
            {
                state = 0;
            }

            // TO DO: if player in attack range, switch state to attack
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
