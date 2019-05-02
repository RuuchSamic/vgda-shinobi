using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Animator animator;
    private Rigidbody2D playerBody;

    public Transform playerTransform;
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    private AudioSource SoundSource;
    public AudioClip[] StepSounds;
    public AudioClip TeleportSound;
    private int soundIndex = 0;
    public static bool teleportHappened;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        SoundSource = GetComponent<AudioSource>();
        teleportHappened = false;
    }

    private void OnEnable()
    {
        if (instance == null)
            instance = this;
    }

    private void OnDisable()
    {
        instance = null;
    }
 
	// Update is called once per frame
	void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            Debug.Log("true");
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            Debug.Log("false");
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            animator.SetBool("PlayerRun", true);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetBool("PlayerRun", false);
        }
        //Get jump animation if jump is true
        else if (jump)
        {
            animator.SetBool("PlayerJump", true);
        }

        if (teleportHappened)
        {
            Debug.Log("PlayerMovement teleport = true");
            animator.SetTrigger("PlayerTeleport");
            SoundSource.PlayOneShot(TeleportSound, 1.0f);
            teleportHappened = false;
        }
       
    }

    void step()
    {
        SoundSource.clip = StepSounds[soundIndex];
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


    public void OnLanding()
    {
        animator.SetBool("PlayerJump", false);
        SoundSource.clip = StepSounds[1];
        SoundSource.Play();
    }

   
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}

