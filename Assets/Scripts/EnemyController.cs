using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour,ICombatTarget
{

    [SerializeField] float health = 100;

    public SpriteRenderer spriteRenderer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damagePoints)
    {

        health-= damagePoints;
        spriteRenderer.color=Color.red;

    }

}
