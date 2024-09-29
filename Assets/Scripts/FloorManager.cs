using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    private float floorStartPosition, floorImageLength;
    public GameObject camera;
    public float parallaxEffectSpeed; // The speed at which the floor moves relative to the camera

    // Start is called before the first frame update
    void Start()
    {
        floorStartPosition = transform.position.x;
        floorImageLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void FixedUpdate()
    {
        // Calculate the distance the floor has to move based on the camera's position
        float distance = (camera.transform.position.x * parallaxEffectSpeed);
        float distanceToMove = camera.transform.position.x * (1 - parallaxEffectSpeed);

        // Move the floor
        transform.position = new Vector3(floorStartPosition + distance, transform.position.y, transform.position.z);

        // If the floor has moved past its length, move it back
        if (distanceToMove > floorStartPosition + floorImageLength)
        {
            floorStartPosition += floorImageLength;
        }
        else if (distanceToMove < floorStartPosition - floorImageLength)
        {
            floorStartPosition -= floorImageLength;
        }
    }
}
