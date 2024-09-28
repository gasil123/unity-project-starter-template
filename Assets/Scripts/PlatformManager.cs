using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;     // Platform prefab
    public Transform playerTransform;     // Player transform to track position
    public float platformSpacing = 8.0f;  // Distance between platforms
    public int initialPlatformCount = 4;  // Number of platforms generated at the start
    public float platformDeleteDistance = 10.0f; // Distance behind player to delete platforms

    private float nextPlatformXPosition = 4.0f;  // X position to generate next platform
    private List<GameObject> activePlatforms = new List<GameObject>();  // Active platform list

    // A toggle flag for alternating between black and white platforms
    private bool isBlack = true;

    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialPlatforms();  // Generate initial platforms
    }

    // Update is called once per frame
    void Update()
    {
        CheckAndGeneratePlatform();  // Continuously check and generate platforms
        DeleteOffscreenPlatforms();  // Continuously check and delete platforms that are off-screen
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

    // Method to generate a new platform at the next X position
    private void GeneratePlatform()
    {
       Vector3 newPlatformPosition = new Vector3(nextPlatformXPosition, 0, 0);

        // Check if the last platform's X position is too close to the new platform's position
        if (activePlatforms.Count > 0 && Mathf.Abs(newPlatformPosition.x - activePlatforms[activePlatforms.Count - 1].transform.position.x) < platformSpacing)
        {
            // Skip platform generation if too close to the previous one
            return;
        }

        // Instantiate the platform prefab
        GameObject platformInstance = Instantiate(platformPrefab, newPlatformPosition, Quaternion.identity);


        // Alternate the color between black and white
        SetPlatformColor(platformInstance);

        // Add the new platform to the active platforms list
        activePlatforms.Add(platformInstance);

        // Update the position for the next platform to be generated
        nextPlatformXPosition += platformSpacing;
    }

    // Method to alternate the platform color between black and white
    private void SetPlatformColor(GameObject platform)
    {
        // Get the SpriteRenderer component of the platform
        SpriteRenderer platformSpriteRenderer = platform.GetComponent<SpriteRenderer>();

        if (isBlack)
        {
            platformSpriteRenderer.color = Color.black;  // Set to black
        }
        else
        {
            platformSpriteRenderer.color = Color.white;  // Set to white
        }

        // Toggle the flag for the next platform
        isBlack = !isBlack;
    }


    // Method to delete platforms that are off-screen (behind the player)
    private void DeleteOffscreenPlatforms()
    {
        // Loop through the active platforms list
        for (int i = activePlatforms.Count - 1; i >= 0; i--)
        {
            // Check if the platform is far behind the player (X axis check for 2D)
            if (playerTransform.position.x - activePlatforms[i].transform.position.x > platformDeleteDistance)
            {
                // Destroy the platform and remove it from the active platforms list
                Destroy(activePlatforms[i]);  // Destroy the platform
                activePlatforms.RemoveAt(i);  // Remove it from the list
            }
        }
    }
}
