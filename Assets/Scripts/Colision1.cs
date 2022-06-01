using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colision1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision");
        if(collision.gameObject.tag == "Player")
        {
            
            SceneManager.LoadScene("Level3",LoadSceneMode.Single);
        }
    }
}
