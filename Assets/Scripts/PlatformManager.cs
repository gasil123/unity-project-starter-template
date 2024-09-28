using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;           // Platform prefab
    public Transform playerTransform;           // Player transform to track position
    public float platformSpacing = 6.0f;        // Distance between platforms
    public int initialPlatformCount = 6;        // Number of platforms generated at the start
    public float platformDeleteDistance = 10.0f; // Distance behind player to deactivate platforms

    private float nextPlatformXPosition = 4.0f;  // X position to generate next platform
    private Queue<GameObject> platformPool = new Queue<GameObject>();  // Queue for platform object pool
    private List<GameObject> activePlatforms = new List<GameObject>(); // List of active platforms

    // Start is called before the first frame update
    void Start()
    {
        InitializePlatformPool();  // Initialize the platform pool
        GenerateInitialPlatforms();  // Generate initial platforms
    }

    // Update is called once per frame
    void Update()
    {
        CheckAndGeneratePlatform();  // Continuously check and generate platforms
        DeactivateOffscreenPlatforms();  // Continuously check and deactivate platforms that are off-screen
    }

    // Method to initialize the platform pool
    private void InitializePlatformPool()
    {
        for (int i = 0; i < initialPlatformCount; i++)
        {
            GameObject platformInstance = Instantiate(platformPrefab);
            platformInstance.SetActive(false);  // Deactivate it initially
            platformPool.Enqueue(platformInstance);  // Add it to the queue
        }
    }

    // Method to generate the initial set of platforms
    private void GenerateInitialPlatforms()
    {
        for (int i = 0; i < initialPlatformCount; i++)
        {
            GeneratePlatform();  // Generate platform for the initial set
        }
    }

    // Check if a new platform needs to be generated based on player position
    private void CheckAndGeneratePlatform()
    {
        if (playerTransform.position.x > nextPlatformXPosition - (initialPlatformCount * platformSpacing))
        {
            GeneratePlatform();
        }
    }

    // Method to generate a platform from the pool at the next X position
    private void GeneratePlatform()
    {
        Vector3 newPlatformPosition = new Vector3(nextPlatformXPosition, 0, 0);

        // Check if the last platform's X position is too close to the new platform's position
        if (activePlatforms.Count > 0 && Mathf.Abs(newPlatformPosition.x - activePlatforms[activePlatforms.Count - 1].transform.position.x) < platformSpacing)
        {
            return;  // Skip generation if too close to the previous platform
        }

        // Get a platform from the pool if available
        GameObject platformInstance = GetPooledPlatform();

        if (platformInstance != null)
        {
            platformInstance.transform.position = newPlatformPosition;
            platformInstance.SetActive(true);  // Reactivate the platform
            activePlatforms.Add(platformInstance);  // Add it to the active list
            nextPlatformXPosition += platformSpacing;  // Update position for the next platform
        }
    }

    // Method to get a platform from the pool
    private GameObject GetPooledPlatform()
    {
        if (platformPool.Count > 0)
        {
            return platformPool.Dequeue();  // Get the first platform in the queue
        }

        // If no platforms available in the pool, instantiate a new one (optional)
        return Instantiate(platformPrefab);
    }

    // Method to deactivate platforms that are off-screen (behind the player)
    private void DeactivateOffscreenPlatforms()
    {
        for (int i = activePlatforms.Count - 1; i >= 0; i--)
        {
            if (playerTransform.position.x - activePlatforms[i].transform.position.x > platformDeleteDistance)
            {
                GameObject platform = activePlatforms[i];
                platform.SetActive(false);  // Deactivate the platform
                activePlatforms.RemoveAt(i);  // Remove it from the active list
                platformPool.Enqueue(platform);  // Return the platform to the pool
            }
        }
    }
}
