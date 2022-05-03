using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hurt : MonoBehaviour
{
    public HealthBarHUDTester health;
    public float damage = 0.25f;
    public Animator animator;

    public PlayerStats pe;

    private float checkPointPositionX, checkPointPositionY;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    // Update is called once per f
    
    void Update()
    {
        
    }

    public void Damaged()
    {
        
        animator.Play("Hurt");
        health.Hurt(damage);
        
        float heal = pe.Health;

        if(heal == 0){
            
            animator.Play("Death");

        }

    }
}
