using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{   
    private float checkPointPositionX, checkPointPositionY;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    public void PlayerDamaged()
    {
        animator.Play("Hurt");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
