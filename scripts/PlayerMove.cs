using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    
    //Cunado corre o no
    public Animator animator;
    
    public SpriteRenderer spriteRenderer;
    
    //Salto y movmiento
    public float runSpeed = 4;
    public float jumpSpeed = 4;
    Rigidbody2D rb2D;


    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
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
       
        if ((Input.GetKey("w") || Input.GetKey("up")) && CheckGround.isGrounded)
        {
            
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
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
        


        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (rb2D.velocity.y > 0 && !(Input.GetKey("up") || Input.GetKey("w")))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}