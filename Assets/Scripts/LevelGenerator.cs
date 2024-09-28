using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Reference to the platform prefab that will be instantiated
    public GameObject platformPrefab;

    // Distance between each platform along the X axis
    public float platformSpacing = 2.0f;

    // Reference to the player transform to track its position
    public Transform playerTransform;

    // Initial position on the X axis for platform generation
    private float nextPlatformXPosition = 3.0f;

    // Number of platforms to generate at the start of the game
    public int initialPlatformCount = 6;

    // Start is called before the first frame update
    void Start()
    {
        // Generate initial platforms when the game starts
        GenerateInitialPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has moved far enough to spawn a new platform
        if (playerTransform.position.x > nextPlatformXPosition - (initialPlatformCount * platformSpacing))
        {
            GeneratePlatform();
        }
    }

    // Method to generate the initial set of platforms
    private void GenerateInitialPlatforms()
    {
        for (int i = 0; i < initialPlatformCount; i++)
        {
            GeneratePlatform();
        }
    }

    // Method to generate a new platform at the next position
    private void GeneratePlatform()
    {
        // Instantiate a new platform at the next X position
        Instantiate(platformPrefab, new Vector3(nextPlatformXPosition, 0, 0), Quaternion.identity);

        // Update the position for the next platform to be generated further along the X axis
        nextPlatformXPosition += platformSpacing;
    }
}
