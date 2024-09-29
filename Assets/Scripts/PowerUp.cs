using System;
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour, ItemInterface
{
    public static event Action<int> OnPowerUpCollect;
    public int powerUpValue = 10;


    public void CollectItem()
    {
        // Add power up effect here
        Debug.Log("Power up collected");

        // Invoke the OnPowerUpCollect event with the power up value
        OnPowerUpCollect.Invoke(powerUpValue);

        // Destroy the power up game object
        Destroy(gameObject);
    }
}