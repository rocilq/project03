using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{   
    private float checkPointPositionX, checkPointPositionY;
    private int life;
    public Animator animator;
    public PlayerStats pe;
    public float damage = 0.25f;
    public HealthBarHUDTester health;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void Update()
    {
        
    }

    public void PlayerDamaged()
    {
        float heal = pe.Health;

        if (heal > 0){
        animator.Play("Hurt");
        health.Hurt(damage);
        }
        
        if(heal == 0){
            animator.Play("Death");
        }

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
