using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class CombateCaC : MonoBehaviour
{
   [SerializeField] private Transform controladorGolpe;
   [SerializeField] private float radioGolpe;
   [SerializeField] private float dañoGolpe;
   [SerializeField] private float tiempoEntreAtaques;
   [SerializeField] private float tiempoSiguienteAtaque;
   private float time = 0;

   float duration = 1.5f;

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

   private void Golpe()
    {

        animator.SetTrigger("Attack");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe); 

        try{

            foreach (Collider2D collision in objetos)
            {
                if (collision.CompareTag("Enemy"))
                {
                    collision.transform.GetComponent<Enemy>().TomarDaño(dañoGolpe);
                    ColorChanger();
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

   void ColorChanger()
     {
        enemy.sp.color = Color.red;

        if (time < 1){ 
            time += Time.deltaTime/duration;
        }
     }
}
