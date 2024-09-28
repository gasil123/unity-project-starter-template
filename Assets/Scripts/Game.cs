using UnityEngine;

public class Game : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject pauseMenu;  // Assign a UI pause menu if you want

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

        // Optional: Show Pause Menu
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;  // Resumes the game globally
        isPaused = false;
        Debug.Log("Game Resumed");

        // Optional: Hide Pause Menu
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
