using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

    public void QuitGame() 
    {
        Debug.Log("QUIT");

        Application.Quit();
    }
}
