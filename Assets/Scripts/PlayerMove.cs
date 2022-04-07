using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float runSpeed = 2;

    float jumpSpeed = 4;

    Rigidbody2D rb2D;

    public SpriteRenderer spriteRenderer;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //Movimiento derecha e izquierda
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
            animator.SetBool("Run",false);
        }
        //Salto
        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        //Si esta en el suelo o no
        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Falling",false);            
        }

        if (rb2D.velocity.y<0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2D.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }

        //Animacion caer
        if (rb2D.velocity.y < 0)
        {
            animator.SetBool("Falling",true);
            
        } else if (rb2D.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
    }

}
