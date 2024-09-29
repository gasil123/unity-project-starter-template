using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, ItemInterface
{
    public void CollectItem()
    {
        // Add power up effect here
        Debug.Log("Power up collected");

        // Destroy the power up object
        Destroy(gameObject);
    }
}