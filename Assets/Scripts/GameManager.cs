using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool isGamePaused = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the player has pressed the "R" key to reload the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        // Check if the player has pressed the "P" key to pause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P key pressed");
            TogglePause();
        }
    }

    // Restart game
    private void Restart()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current active scene
        Debug.Log("Restarting...");
        SceneManager.LoadScene(currentScene.name);
    }

    // Toggle Pause game
    private void TogglePause()
    {
        Debug.Log("TogglePause");
        // Check if the game is paused
        if (isGamePaused == true)
        {
            // Unpause the game
            Time.timeScale = 1f;
            isGamePaused = false;
            Debug.Log("Game Unpaused");
            return;
        }


        // Pause the game
        Time.timeScale = 0f;
        isGamePaused = true;
        Debug.Log("Game Paused");
    }
}
