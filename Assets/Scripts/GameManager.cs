using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Check if the player has pressed the "R" key to reload the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
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

}
