﻿using System.Collections;
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
    bool onGround = true;
    private AudioSource StepSource;
    public AudioClip[] StepSounds;
    private int soundIndex = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        StepSource = GetComponent<AudioSource>();
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

        //If player is on the ground but the jump animation is on, turn it off.
        //if (!jump)
        //{
        //    animator.SetBool("PlayerJump", false);
        //    Debug.Log("Player not in air");
        //}

        //Left and Right Movement animation switch
        //if (playerBody.velocity.y < -1 && !onGround)
        //{
        //    animator.SetBool("PlayerFall", true);
        //}
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
            Debug.Log("Player in air");
        }

       
    }

    void step()
    {
        StepSource.PlayOneShot(StepSounds[soundIndex], 1f);

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
        animator.SetBool("PlayerFall", false);
    }


    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        Debug.Log("Jump == False");
    }
}

