using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDown : MonoBehaviour, ItemInterface
{
    public void CollectItem()
    {
        // Add power up effect here
        Debug.Log("Power down collected");

        // Destroy the power up object
        Destroy(gameObject);
    }
}