using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public float horizontalMove = 0f;

    public float verticalMove = 0f;

    public Joystick joystick;

    public float runSpeedHorizontal = 2;
    
    public float runSpeed = 1.25f;

    public float jumpSpeed = 4;

    Rigidbody2D rb2D;

    public SpriteRenderer spriteRenderer;
   
   CombateCaC combat;
   [SerializeField] private float radioGolpe = 0.2f;
   [SerializeField] private float dañoGolpe = 50;
   
   [SerializeField] private float tiempoEntreAtaques = 1;
   [SerializeField] private float tiempoSiguienteAtaque = 0;

    public Animator animator;

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    void Update()
    {   
        if (horizontalMove>0)
        {

            //rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

        } 
        
        else if (horizontalMove<0)
        {
            //rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

        } 
        
        else
        {
            //rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run",false);
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
            animator.SetBool("Falling", false);
        }

        //Animacion caer
        if (rb2D.velocity.y<0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2D.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
        
        //Animacion caer
        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Falling", true);
        }
        else if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Falling", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {   

        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position+= new Vector3(horizontalMove,0,0)*Time.deltaTime*runSpeed;

    }

    public void Jump(){

        if (CheckGround.isGrounded){
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
    }

    public void Attack(){
        try{

        
            if(tiempoSiguienteAtaque > 0){
                tiempoSiguienteAtaque -= Time.deltaTime;
            }
            if(tiempoSiguienteAtaque <= 0)
            {
                Golpe();
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }

        }catch(NullReferenceException e){
            Console.WriteLine(e);
        }
    }

    public void Golpe()
    {
        animator.SetTrigger("Attack");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(combat.controladorGolpe.position, radioGolpe); 

        try{

            foreach (Collider2D collision in objetos)
            {
                if (collision.CompareTag("Enemy"))
                {
                    collision.transform.GetComponent<Enemy>().TomarDaño(dañoGolpe);
                }
            }

        }catch(NullReferenceException e){
            Console.WriteLine(e);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
    }
}
