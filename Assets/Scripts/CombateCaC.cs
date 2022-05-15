using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class CombateCaC : MonoBehaviour
{
   [SerializeField] public Transform controladorGolpe;
   [SerializeField] private float radioGolpe = 0.2f;
   [SerializeField] private float dañoGolpe = 50;
   [SerializeField] private float tiempoEntreAtaques = 1;
   [SerializeField] private float tiempoSiguienteAtaque = 0;

   Enemy enemy;


    private Animator animator;
   
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(tiempoSiguienteAtaque > 0){
            tiempoSiguienteAtaque -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }

   public void Golpe()
    {

        animator.SetTrigger("Attack");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe); 

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

   private void OnDrawGizmos()
   {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
   }
}
