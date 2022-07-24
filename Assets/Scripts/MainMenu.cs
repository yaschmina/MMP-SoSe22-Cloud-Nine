using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
// Szene springt eine Szene weiter auf Intro
    }
    public void QuitGame ()
    {
	Debug.Log("QUIT!");
	Application.Quit();
    }
    public void goToMenu () 
    {
        SceneManager.LoadScene("Menu");
    }
    public void goToGame ()
    {
        SceneManager.LoadScene("Jump and Run 1");
    }
   
}
