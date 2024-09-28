public class Platform
{
    // Position of the platform in the game world
    public Vector2 PlatformPosition { get; private set; }

    // Reference to the instantiated platform GameObject
    public GameObject PlatformGameObject { get; private set; }
    
    // Constructor to create a platform at a given position using a prefab
    public Platform(GameObject platformPrefab, Vector2 startPosition)
    {
        // Instantiate the platform prefab at the start position
        PlatformGameObject = GameObject.Instantiate(platformPrefab, startPosition, Quaternion.identity);

        // Set the initial position of the platform
        PlatformPosition = startPosition;
    }

    // Function to move the platform to the right at a given speed
    public void MovePlatform(float movementSpeed)
    {
        // Update the platform's position by moving it to the right
        PlatformPosition += Vector2.right * movementSpeed * Time.deltaTime;

        // Apply the new position to the platform GameObject
        PlatformGameObject.transform.position = PlatformPosition;
    }

    // Function to check if the platform is off the screen
    public bool IsOffScreen()
    {
        // Return true if the platform's position is less than -10 on the X axis
        return PlatformGameObject.transform.position.x < -10f;  // Example boundary for off-screen check
    }

    // Function to reposition the platform to a new position
    public void Reposition(Vector2 newPosition)
    {
        // Set the new position of the platform
        PlatformPosition = newPosition;

        // Apply the new position to the platform GameObject
        PlatformGameObject.transform.position = PlatformPosition;
    }

    // Function to destroy the platform GameObject
    public void DestroyPlatform()
    {
        // Destroy the platform GameObject
        GameObject.Destroy(PlatformGameObject);
    }
}