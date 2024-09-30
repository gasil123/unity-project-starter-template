using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int coins = 200;
    public TextMeshProUGUI coinsDisplayText;
    public TextMeshProUGUI speedDisplayText;
    public int PowerUpValue = 100;
    public int PowerDownValue = 100;
    public Player playerGameObject;
    public int difficultyIncreaseIntervalSecs = 5;

    void Start()
    {
        StartCoroutine(IncreaseDifficulty());
        coinsDisplayText.text = "Coins: " + coins.ToString();
        speedDisplayText.text = "Speed: " + playerGameObject.movementSpeed.ToString();
        // Subscribe to the OnPowerUpCollect event
        PowerUp.OnPowerUpCollect += (value) => IncreaseCoins(value != 0 ? value : PowerUpValue);
        PowerDown.OnPowerDownCollect += (value) => DecreaseCoins(value != 0 ? value : PowerDownValue);
    }

    void IncreaseCoins(int powerUpValueArg)
    {
        coins += powerUpValueArg;
        coinsDisplayText.text = "Coins: " + coins.ToString();
        // log coins with timestamp
        Debug.Log("coins Increased");
        Debug.Log("Time: " + Time.time + " coins: " + coins);
    }

    void DecreaseCoins(int powerDownValue)
    {
        coins -= powerDownValue;
        coinsDisplayText.text = "Coins: " + coins.ToString();
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

    IEnumerator IncreaseDifficulty()
    {
        while (true)
        {
            // Increase the difficulty of the game
            Debug.Log("Difficulty Increased");

            // Increase the player's speed by 5
            playerGameObject.movementSpeed += 5;
            Debug.Log("Player speed: " + playerGameObject.movementSpeed);

            // update speed display text
            speedDisplayText.text = "Speed: " + playerGameObject.movementSpeed.ToString();

            // Wait for the specified interval before increasing the difficulty again
            yield return new WaitForSeconds(difficultyIncreaseIntervalSecs);
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
