using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ground;
    public GameObject powerUpPrefab;
    public GameObject powerDownPrefab;
    public float initialSpawnInterval = 2f; // Initial time interval between spawns
    public float spawnIntervalIncreaseRate = 0.1f; // Rate at which the spawn interval increases
    public float maxSpawnInterval = 5f; // Maximum time interval between spawns

    private float currentSpawnInterval;
    private float nextSpawnTime;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        nextSpawnTime = Time.time + currentSpawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomNumberOfItems();
            nextSpawnTime = Time.time + currentSpawnInterval;

            // Increase the spawn interval over time
            currentSpawnInterval = Mathf.Min(currentSpawnInterval + spawnIntervalIncreaseRate, maxSpawnInterval);
        }
    }

    void SpawnRandomNumberOfItems()
    {
        // Generate a random number of items to spawn
        int numberOfItems = Random.Range(1, 4);

        for (int i = 0; i < numberOfItems; i++)
        {
            SpawnItem();
        }
    }
    
    void SpawnItem()
    {
        // Randomly choose between PowerUp and PowerDown
        GameObject itemPrefab = Random.value > 0.5f ? powerUpPrefab : powerDownPrefab;

        // Generate random x and y positions within the specified range
        float randomX = player.transform.position.x + Random.Range(20f, 40f); // Random x value in front of the player
        float randomY = Random.Range(-5.7f, 1.0f); // Random y value between ground and player's jump height

        Debug.Log("Spawning item at: " + randomX + ", " + randomY);
        // Instantiate the item at the random position
        Instantiate(itemPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
    }
}