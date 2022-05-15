using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;
    public SpriteRenderer sp;
    
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void TomarDaño(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Death");
        Destroy(gameObject,.5f);
    }

}
