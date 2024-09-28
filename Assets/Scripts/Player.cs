using UnityEngine;

public class Player : MonoBehaviour
{
    // Player's movement speed (adjustable in the Inspector)
    public float movementSpeed = 5f;

    // Force applied to the player to make them jump (adjustable in the Inspector)
    public float jumpForce = 10f;

    // Player's health points (adjustable in the Inspector)
    public int healthPoints = 100;

    // Reference to the Rigidbody2D component attached to the player
    private Rigidbody2D playerRigidbody2D;

    // Boolean to check if the player is on the ground
    private bool isPlayerGrounded;

    // Initialize values in the Start method
    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player movement
        MovePlayer();

        // Handle jumping if spacebar is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerGrounded)
        {
            Jump();
        }
    }

    // Function to move the player horizontally
    public void MovePlayer()
    {
        // Create a new Vector2 for movement with the player's speed and current vertical velocity
        Vector2 movement = new Vector2(movementSpeed, playerRigidbody2D.velocity.y);

        // Set the player's Rigidbody2D velocity to the new movement vector
        playerRigidbody2D.velocity = movement;
    }

    // Function to make the player jump
    public void Jump()
    {
        // Apply a force to the player's Rigidbody2D to make them jump
        playerRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // Set isPlayerGrounded to false because the player is now in the air
        isPlayerGrounded = false;
    }

    // Detect when the player lands on the ground using OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player lands on something tagged as "Platform," consider them grounded
        if (collision.gameObject.CompareTag("Platform"))
        {
            isPlayerGrounded = true;
        }
    }

    // Detect when the player leaves the ground using OnCollisionExit2D
    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the player leaves the platform, they are not grounded anymore
        if (collision.gameObject.CompareTag("Platform"))
        {
            isPlayerGrounded = false;
        }
    }
}
