using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fade : MonoBehaviour
{
    private Animator anim;
    [SerializeField] string nivel;
    //
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PasarNivel()
    {
        SceneManager.LoadScene(nivel);
    }

    public void HacerFade()
    {
        anim.SetTrigger("fadeout");
    }
}
