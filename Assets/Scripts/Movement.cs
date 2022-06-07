using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour {

    //1. Declaración de variables
    [Range(1, 10)] public float velocidad; //Velocidad del jugador
    Rigidbody2D rb2d;
    SpriteRenderer spRd;
    bool isJumping = false; //Para comprobar si ya está saltando
    [Range(1, 500)] public float potenciaSalto; //Potencia de salto del jugador
    private Animator animator; //Para campturar el componente Animator del Jugador

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    private Vector3 respawnPoint1;
    public GameObject fallDetector1;
    private Vector3 respawnPoint2;
    public GameObject fallDetector2;

    void Start () {

        //2. Capturo y asocio los componentes Rigidbody2D y Sprite Renderer del Jugador
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //checkpoint = GameObject.Find("CheckPoint").transform.position;
        respawnPoint = fallDetector.transform.position;
        respawnPoint1 = fallDetector1.transform.position;
        respawnPoint2 = fallDetector2.transform.position;
    }
	
	void FixedUpdate () {

        //3. Movimiento horizontal
        float movimientoH = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(movimientoH * velocidad, rb2d.velocity.y);

        //4. Sentido horizontal (para girar el render del jugador)
        if (movimientoH > 0)
        {
            spRd.flipX = false;
        }
        else if (movimientoH < 0)
        {
            spRd.flipX = true;
        }
        if (Input.GetButton("Jump") && !isJumping)
        {
            //Le aplico la fuerza de salto
            rb2d.AddForce(Vector2.up * potenciaSalto);
            //Digo que está saltando (para que no pueda volver a saltar)
            isJumping = true;
            animator.SetBool("Jump", true);
        }

        if (movimientoH != 0)
        {
            animator.SetBool("Run", true); //Si se está moviendo, reproduzco la animación
        }
        else
        {
            animator.SetBool("Run", false); //Si no, la paro
        }
        
        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Run", false);
            
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Falling", false);
        }
        
        if (rb2d.velocity.y<0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2d.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }


    }
    /**** AÑADIR COMO NUEVO MÉTODO (ANTES DE LA ÚLTIMA LLAVE DE CIERRE } DE LA CLASE ****/

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Si el jugador colisiona con un objeto con la etiqueta suelo
        if (other.gameObject.CompareTag("Suelo"))
        {
            animator.SetBool("Jump", false);
            //Digo que no está saltando (para que pueda volver a saltar)
            isJumping = false;
            //Le quito la fuerza de salto remanente que tuviera
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;

        } else if (collision.tag == "FallDetector1")
        {
            transform.position = respawnPoint1;

        } else if (collision.tag == "FallDetector2")
        {
            transform.position = respawnPoint2;
        }
    }
}
