using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 50.0f;

    float horizontalMove = 0.0f;
    bool grounded = true;
    bool jump = false;
    bool crouch = false; // not in-use

    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null) 
        {
            controller = GetComponent<CharacterController2D>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // manage horizontal movement input
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // manage when to play the jumping anim
        if (!grounded)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        // check jump input
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jump = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        // disable jumping when on ground
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // enable jump when flying off the ground
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))  
        {      
            grounded = false;
        }          
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    // Apply movement physics here
    void FixedUpdate()
    {
        // Move player character via the controller
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
