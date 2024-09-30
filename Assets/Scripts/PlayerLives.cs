using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int maxHearts = 4; // Maximum number of hearts
    public int currentHealth; // Current health

    public LivesManager livesManager; // Reference to the LivesManager game object
    
    void Start()
    {
        // Set the maximum number of hearts
        livesManager.SetMaxHearts(maxHearts);
        // Set the current health to the maximum number of hearts
        currentHealth = 100;
        // Update the hearts display
        livesManager.UpdateHearts(currentHealth);
    }

    
    // 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player has collided with an object tagged "Trap"
        if (collision.CompareTag("Trap"))
        {
            // Decrease the player's health by 10
            currentHealth -= 10;
            
            if (currentHealth <= 0)
            {
                // if the player's health is less than or equal to 0, the player loses a life/heart
                // the game reloads the scene with one less heart, and the player's health is reset to 100
                maxHearts--;
                currentHealth = 100;
            }

        }
    }

}
