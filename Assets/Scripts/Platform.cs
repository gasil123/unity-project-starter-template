using UnityEngine;

public class Platform : MonoBehaviour
{
    // Position of the platform in the game world
    public Vector2 PlatformPosition { get; private set; }

    // Reference to the instantiated platform GameObject
    public GameObject PlatformGameObject { get; private set; }

    // Initialize the platform with a prefab and start position
    public void Initialize(GameObject platformPrefab, Vector2 startPosition)
    {
        // Set the initial position of the platform
        PlatformPosition = startPosition;

        // Set the reference to the platform GameObject
        PlatformGameObject = platformPrefab;

        // Set the position of the platform GameObject
        transform.position = PlatformPosition;
    }

    // Function to move the platform to the left at a given speed
    public void MovePlatform(float movementSpeed)
    {
        // Update the platform's position by moving it to the left
        PlatformPosition += Vector2.left * movementSpeed * Time.deltaTime;

        // Apply the new position to the platform GameObject
        transform.position = PlatformPosition;
    }

    // Function to check if the platform is off the screen
    public bool IsOffScreen()
    {
        // Return true if the platform's position is less than -10 on the X axis
        return transform.position.x < -10f;  // Example boundary for off-screen check
    }

    // Function to reposition the platform to a new position
    public void Reposition(Vector2 newPosition)
    {
        // Set the new position of the platform
        PlatformPosition = newPosition;

        // Apply the new position to the platform GameObject
        transform.position = PlatformPosition;
    }

    // Function to destroy the platform GameObject
    public void DestroyPlatform()
    {
        // Destroy the platform GameObject
        Destroy(gameObject);
    }
}
