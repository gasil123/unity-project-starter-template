using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private float backgroundStartPosition, backgroundImageLength;
    public GameObject camera;
    public float parallaxEffectSpeed; // The speed at which the background moves relative to the camera

    // Start is called before the first frame update
    void Start()
    {
        backgroundStartPosition = transform.position.x;
        backgroundImageLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void FixedUpdate()
    {
        // Calculate the distance the background has to move based on the camera's position
        float distance = (camera.transform.position.x * parallaxEffectSpeed);
        float distanceToMove = camera.transform.position.x * (1 - parallaxEffectSpeed);

        // Move the background
        transform.position = new Vector3(backgroundStartPosition + distance, transform.position.y, transform.position.z);

        // If the background has moved past its length, move it back
        if (distanceToMove > backgroundStartPosition + backgroundImageLength)
        {
            backgroundStartPosition += backgroundImageLength;
        }
        else if (distanceToMove < backgroundStartPosition - backgroundImageLength)
        {
            backgroundStartPosition -= backgroundImageLength;
        }
    }
}
