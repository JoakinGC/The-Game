using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJockStick : MonoBehaviour
{
    private float horizontalMove = 0f;
    
    private float verticalMove = 0f;

    public Joystick joystick;
    
    //Cunado corre o no
    
    
    public Animator animator;
    
    public SpriteRenderer spriteRenderer;
    
    //Salto y movmiento
    public float runSpeed = 2;
    public float jumpSpeed = 8;
    Rigidbody2D rb2D;


    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void update()
    {
        
    }

    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeed;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
        
        
        if (horizontalMove>0)
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (horizontalMove<0)
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }
       
        
        
        //Salto Animacion

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            
        }
    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
    }
}
