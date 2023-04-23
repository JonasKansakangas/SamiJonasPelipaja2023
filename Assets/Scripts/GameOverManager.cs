using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    #region Members
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI finalScore;
    #endregion

    #region Methods
    /// <summary>
    /// Displays a game over screen and shows the score
    /// </summary>
    public void SetGameOver() 
    {
        gameOverScreen.SetActive(true);

        finalScore.text = currentScore.text;
        
        currentScore.gameObject.SetActive(false);

        Time.timeScale = 0;
    }

    /// <summary>
    /// Restart game
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Quit the game and return to main menu
    /// </summary>
    public void QuitRun()
    {
        SceneManager.LoadScene(1);
    }
    #endregion
}
