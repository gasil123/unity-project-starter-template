using System;
using System.Collections;
using UnityEngine;


public class PowerDown : MonoBehaviour, ItemInterface
{
    public static event Action<int> OnPowerDownCollect;
    public int powerDownValue = 10;


    public void CollectItem()
    {
        // Add power up effect here
        Debug.Log("Power up collected");

        // Invoke the OnPowerDownCollect event with the power up value
        OnPowerDownCollect.Invoke(powerDownValue);

        // Destroy the power up game object
        Destroy(gameObject);
    }
}