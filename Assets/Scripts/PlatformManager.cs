using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;

    public Platform CreatePlatform(Vector2 startPosition)
    {
        // Instantiate platform prefab from this MonoBehaviour
        GameObject platformObject = Instantiate(platformPrefab, startPosition, Quaternion.identity);
        return new Platform(platformObject, startPosition);
    }

    // Handle platform destruction here
    public void DestroyPlatform(Platform platform)
    {
        Destroy(platform.PlatformGameObject);  // Use MonoBehaviour's Destroy method
    }
}
