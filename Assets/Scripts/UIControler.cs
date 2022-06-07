using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControler : MonoBehaviour
{

    public GameObject optionsPanel;

    public void Pause()
    {
        Time.timeScale = 0f;
        optionsPanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        optionsPanel.SetActive(false);
    }

    public void AnotherOptions()
    {
        //sonidos o graficos 
        SceneManager.LoadScene("Settings");
    }

    public void AnotherOptions1()
    {
        //sonidos o graficos 
        SceneManager.LoadScene("Settings1");
    }

    public void AnotherOptions2()
    {
        //sonidos o graficos 
        SceneManager.LoadScene("Settings2");
    }

    public void Restart()
    {
        //sonidos o graficos 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }


    public void GoMainMenu()
    {
        //reinicia la partida de momento
        SceneManager.LoadScene("SampleScene");

    }

    public void GoNivel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoNivel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void sceneGame()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }
}
