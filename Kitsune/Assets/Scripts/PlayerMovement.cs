using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Rigidbody2D playerBody;
    private bool groundBool = true;
    private Animator animator;
    [SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f;                                         // Radius of the overlap circle to determine if grounded
    [SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

    public Transform playerTransform;
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
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
        if (groundBool)
        {
            animator.SetBool("PlayerJump", false);
            animator.SetBool("PlayerFall", false);
            Debug.Log("Player not in air");
        }

        //Left and Right Movement animation switch
        if (Input.GetButtonDown("Horizontal") && groundBool)
        {
            animator.SetBool("PlayerRun", true);
        }
        else if (Input.GetButtonUp("Horizontal") && groundBool)
        {
            animator.SetBool("PlayerRun", false);
        }

        //Get jump animation if jump is true
        else if (playerBody.velocity.y > 0 && !groundBool)
        {
            animator.SetBool("PlayerJump", true);
            animator.SetBool("PlayerRun", false);
            Debug.Log("Player in air");
        }

        else if (playerBody.velocity.y == 0 && !groundBool)
        {
            animator.SetBool("PlayerJumpTransition", true);
            animator.SetBool("PlayerJump", false);
            animator.SetBool("PlayerRun", false);
        }


        

    }

    void FixedUpdate()
    {
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                groundBool = true;
            }
            else
            {
                groundBool = false;
            }
        }
    

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
