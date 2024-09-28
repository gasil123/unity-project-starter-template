using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f;    // Movement speed
    public float jumpForce = 10f;       // Jump force
    public int healthPoints = 100;      // Health points

    public Transform groundCheck;       // Reference to a point at the bottom of the player for ground detection
    public float groundCheckRadius = 0.2f; // The radius of the ground check circle
    public LayerMask groundLayer;       // LayerMask to specify which layers should be considered ground

    private Rigidbody2D playerRigidbody2D;
    private bool isPlayerGrounded;

    void Start()
    {
        // Get the Rigidbody2D component
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Perform ground check using an overlap circle at the player's feet
        isPlayerGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Move player horizontally
        MovePlayer();

        // Jump when space is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerGrounded)
        {
            Jump();
        }
    }

    void MovePlayer()
    {
        Vector2 movement = new Vector2(movementSpeed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = movement;
    }

    void Jump()
    {
        playerRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
