using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{  
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 10f;
    bool jump = false;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public void OnGround(){
        animator.SetBool("IsGrounded", true);
        jump = false;
    }
    void FixedUpdate(){
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        
        if(Input.GetButtonDown("Jump") || Input.GetButton("Jump")){
            jump = true;
            animator.SetBool("IsGrounded", false);
        }
        
    }
}
