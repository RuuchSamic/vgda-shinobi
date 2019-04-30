using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static bool seesPlayer;
    private Animator anim;
    public float speed;
    public float distance;
    public int state; // 0 = idle; 1 = atk; 2 = walk;

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

        // if idle
        if (state == 0)
        {

        }

        // if atk 
        if (state == 1)
        {

        }

        // if walking
        if (state == 2)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, m_CollideWith);
            RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 0, m_CollideWith);

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
