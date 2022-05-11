using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player Damaged");

        collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        
    }
}
