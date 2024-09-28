using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Game game;

    void Start()
    {
        // Initialize the Game class for handling global states
        game = gameObject.AddComponent<Game>();

        // Perform other initialization here
    }

    void Update()
    {
        // Example: Using the Game class to manage the game state
        if (Input.GetKeyDown(KeyCode.P))
        {
            game.TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            game.QuitGame();
        }
    }
}
