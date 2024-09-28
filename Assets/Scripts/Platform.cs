using UnityEngine;

public class Platform : MonoBehaviour
{
    // Initialize the platform at a start position
    public void Initialize(Vector2 startPosition)
    {
        // Set the initial position of the platform
        transform.position = startPosition;
    }

    // Function to move the platform to the left at a given speed
    public void MovePlatform(float movementSpeed)
    {
        // Move the platform left by the given speed
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }

    // Function to check if the platform is off the screen
    public bool IsOffScreen()
    {
        // Return true if the platform's X position is less than -10 (example boundary)
        return transform.position.x < -10f;  // Adjust boundary as needed
    }

    // Function to reposition the platform to a new position
    public void Reposition(Vector2 newPosition)
    {
        // Set the new position of the platform
        transform.position = newPosition;
    }

    // Function to deactivate the platform (for object pooling)
    public void DeactivatePlatform()
    {
        // Deactivate the platform GameObject for later reuse
        gameObject.SetActive(false);
    }
}
