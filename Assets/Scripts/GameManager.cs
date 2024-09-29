using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int coins = 20;
    public TextMeshProUGUI coinsDisplayText;
    public int PowerUpValue = 10;
    public int PowerDownValue = 10;

    void Start()
    {
        coinsDisplayText.value = 0;
        // Subscribe to the OnPowerUpCollect event
        PowerUp.OnPowerUpCollect += (value) => IncreaseCoins(value != 0 ? value : PowerUpValue);
        PowerDown.OnPowerDownCollect += (value) => DecreaseCoins(value != 0 ? value : PowerDownValue);
    }

    void IncreaseCoins(int powerUpValueArg)
    {
        coins += powerUpValueArg;
        coinsDisplayText.value = coins;
        // log coins with timestamp
        Debug.Log("coins Increased");
        Debug.Log("Time: " + Time.time + " coins: " + coins);
    }

    void DecreaseCoins(int powerDownValue)
    {
        coins -= powerDownValue;
        coinsDisplayText.value = coins;
        // log coins with timestamp
        Debug.Log("coins Decreased");
        Debug.Log("Time: " + Time.time + " coins: " + coins);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has pressed the "R" key to reload the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    // Restart game
    private void Restart()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current active scene
        Debug.Log("Restarting...");
        SceneManager.LoadScene(currentScene.name);
    }

}
