using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Game game;  // Reference to the Game script

    void Start()
    {
        // Ensure that the game object is assigned in the Inspector
        if (game == null)
        {
            game = gameObject.GetComponent<Game>();
        }
    }

    void Update()
    {
        // Toggle Pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            game.TogglePause();
        }

        // Quit Game
        if (Input.GetKeyDown(KeyCode.Q))
        {
            game.QuitGame();
        }
    }
}
