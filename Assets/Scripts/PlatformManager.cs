using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;     // Platform prefab
    public Transform playerTransform;     // Player transform to track position
    public float platformSpacing = 2.0f;  // Distance between platforms
    public int initialPlatformCount = 6;  // Number of platforms generated at the start

    private float nextPlatformXPosition = 3.0f;  // X position to generate next platform
    private List<Platform> activePlatforms = new List<Platform>();  // Active platform list

    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialPlatforms();  // Generate initial platforms
    }

    // Update is called once per frame
    void Update()
    {
        CheckAndGeneratePlatform();  // Continuously check and generate platforms
    }

    // Method to generate the initial set of platforms
    private void GenerateInitialPlatforms()
    {
        for (int i = 0; i < initialPlatformCount; i++)
        {
            GeneratePlatform();  // Generate platform for the initial set
        }
    }

    // Check if new platform needs to be generated based on player position
    private void CheckAndGeneratePlatform()
    {
        if (playerTransform.position.x > nextPlatformXPosition - (initialPlatformCount * platformSpacing))
        {
            GeneratePlatform();
        }
    }

    // Method to generate a new platform at the next X position
    private void GeneratePlatform()
    {
        Vector3 newPlatformPosition = new Vector3(nextPlatformXPosition, 0, 0);
        Platform newPlatform = gameObject.AddComponent<Platform>();
        activePlatforms.Add(newPlatform);

        // Update the position for the next platform to be generated
        nextPlatformXPosition += platformSpacing;
    }
}
