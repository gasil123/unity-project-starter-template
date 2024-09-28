using UnityEngine;

public class Game
{
    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;  // Pauses the game globally
        isPaused = true;
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;  // Resumes the game globally
        isPaused = false;
        Debug.Log("Game Resumed");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
