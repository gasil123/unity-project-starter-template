using System;
using System.Collections;
using UnityEngine;


public class Trap : MonoBehaviour, ItemInterface
{
    public static event Action<int> OnTrapCollect;
    public int trapValue = 100;


    public void CollectItem()
    {
        // Add power up effect here
        Debug.Log("Trap activated");

        // Invoke the OnTrapCollect event with the power up value
        OnTrapCollect.Invoke(trapValue);

        // Destroy the power up game object
        Destroy(gameObject);
    }
}