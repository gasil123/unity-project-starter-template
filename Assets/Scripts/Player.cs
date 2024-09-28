public class Player
{
    // Player's movement speed
    public float MovementSpeed { get; set; }

    // Force applied to the player to make them jump
    public float JumpForce { get; set; }

    // Player's health points
    public int HealthPoints { get; set; }
    
    // Reference to the RigidBody2D component attached to the player
    private RigidBody2D playerRigidBody2D;

    // Boolean to check if the player is on the ground
    private bool isPlayerGrounded;

    // Constructor to initialize the player with RigidBody2D, speed, jump force, and health
    public Player(RigidBody2D rigidBody2D, float movementSpeed, float jumpForce, int healthPoints)
    {
        playerRigidBody2D = rigidBody2D;
        MovementSpeed = movementSpeed;
        JumpForce = jumpForce;
        HealthPoints = healthPoints;
    }

    // Function to move the player horizontally
    public void MovePlayer()
    {
        // Create a new Vector2 for movement with the player's speed and current vertical velocity
        Vector2 movement = new Vector2(MovementSpeed, playerRigidBody2D.velocity.y);

        // Set the player's RigidBody2D velocity to the new movement vector
        playerRigidBody2D.velocity = movement;
    }

    // Function to make the player jump
    public void Jump()
    {
        // Check if the player is on the ground
        if (isPlayerGrounded)
        {
            // Apply a force to the player's RigidBody2D to make them jump
            playerRigidBody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

            // Set isPlayerGrounded to false because the player is now in the air
            isPlayerGrounded = false;
        }
    }

    // Function to call when the player lands on the ground
    public void OnLanding()
    {
        // Set isPlayerGrounded to true because the player is now on the ground
        isPlayerGrounded = true;
    }
}
