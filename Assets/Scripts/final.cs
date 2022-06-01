using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    public GameObject panel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision");
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            panel.SetActive(true);


        }
    }
}
