using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score = 200;
    int maxHealth = 100;
    int currentHealth = 100;
    public Slider healthBar;
    public TextMeshProUGUI scoreDisplayText;
    public TextMeshProUGUI speedDisplayText;
    public int PowerUpValue = 100;
    public int TrapValue = 10;
    public Player playerGameObject;
    public int difficultyIncreaseIntervalSecs = 10;

    void Start()
    {
        StartCoroutine(IncreaseDifficulty());
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        scoreDisplayText.text = "Score: " + score.ToString();
        speedDisplayText.text = "Speed: " + playerGameObject.movementSpeed.ToString();
        // Subscribe to the OnPowerUpCollect event
        PowerUp.OnPowerUpCollect += (value) => UpdateScore(value != 0 ? value : PowerUpValue);
        // Trap.OnTrapCollect += (value) => DecreaseScore(value != 0 ? value : TrapValue);
        Trap.OnTrapCollect += (value) => UpdateHealthDisplay(value != 0 ? value : TrapValue);
    }

    void UpdateScore(int valueArg)
    {
        score += valueArg;
        scoreDisplayText.text = "Score: " + score.ToString();
        // log score with timestamp
        // Debug.Log("score Increased");
        // Debug.Log("Time: " + Time.time + " score: " + score);
    }

    void UpdateHealthDisplay(int valueArg)
    {
        currentHealth -= valueArg;
        healthBar.value = currentHealth;
        // log score with timestamp
        // Debug.Log("score Decreased");
        // Debug.Log("Time: " + Time.time + " score: " + score);
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
            // Debug.Log("Difficulty Increased");

            // Increase the player's speed by 2
            playerGameObject.movementSpeed += 2;
            // Debug.Log("Player speed: " + playerGameObject.movementSpeed);

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
