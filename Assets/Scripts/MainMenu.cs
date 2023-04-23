using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Starts a new game
    /// </summary>
    public void PlayGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame() 
    {
        Debug.Log("QUIT");

        Application.Quit();
    }
}
