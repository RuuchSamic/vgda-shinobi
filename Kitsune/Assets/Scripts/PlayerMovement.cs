using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Animator animator;

    private void Start()
    {
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
        
        //Left and Right Movement animation switch
        if (Input.GetButtonDown("Horizontal") && !jump)
        {
            animator.SetBool("PlayerRun", true);
        }
        else if (Input.GetButtonUp("Horizontal") && !jump)
        {
            animator.SetBool("PlayerRun", false);
        }

        //Get jump animation if jump is true
        if (jump)
        {
            animator.SetBool("PlayerJump", true);
            Debug.Log("Player in air");
        }
        else if (!jump)
        {
            animator.SetBool("PlayerJump", false);
            Debug.Log("Player not in air");
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
