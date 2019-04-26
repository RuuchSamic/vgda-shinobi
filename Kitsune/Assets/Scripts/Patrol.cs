using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;
    [SerializeField] private LayerMask m_CollideWith;

    public Transform groundDetection;

    private AudioSource SoundSource;
    public AudioClip[] StepSoundsEnemy;
    private int soundIndex = 0;

    private void Start()
    {
        SoundSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //RaycastHit[] groundInfo = Physics2D.RaycastAll(groundDetection.position);
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

        /**
        void OnCollisionEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "wall")
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
        }**/

    }

    //Plays Sounds for footsteps
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