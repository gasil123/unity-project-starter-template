using UnityEngine;

public class Platform
{
    // Position of the platform in the game world
    public Vector2 PlatformPosition { get; private set; }

    // Reference to the instantiated platform GameObject
    public GameObject PlatformGameObject { get; private set; }

    // Constructor to create a platform using an already-instantiated GameObject
    public Platform(GameObject platformGameObject, Vector2 startPosition)
    {
        PlatformGameObject = platformGameObject;
        PlatformPosition = startPosition;
    }

    // Function to move the platform to the right at a given speed
    public void MovePlatform(float movementSpeed)
    {
        PlatformPosition += Vector2.right * movementSpeed * Time.deltaTime;
        PlatformGameObject.transform.position = PlatformPosition;
    }

    // Function to check if the platform is off the screen
    public bool IsOffScreen()
    {
        return PlatformGameObject.transform.position.x < -10f;  // Example boundary for off-screen check
    }

    // Function to reposition the platform to a new position
    public void Reposition(Vector2 newPosition)
    {
        PlatformPosition = newPosition;
        PlatformGameObject.transform.position = PlatformPosition;
    }
}
