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

   

    private void Update()
    {
        
            Golpe();
        
    }

   private void Golpe()
    {
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
