using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControler : MonoBehaviour
{

    public GameObject optionsPanel;

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(false);
    }

    public void AnotherOptions()
    {
        //sonidos o graficos 
    }

    public void GoMainMenu()
    {
        //reinicia la partida de momento
        SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}