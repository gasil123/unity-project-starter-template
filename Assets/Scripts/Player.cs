using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody2D;
    public Animator playerAnimator;

    public float movementSpeed = 5f;    // Movement speed
    public float jumpForce = 10f;       // Jump force
    public int healthPoints = 100;      // Health points

    public Transform groundCheck;       // Reference to a point at the bottom of the player for ground detection
    public float groundCheckRadius = 0.2f; // The radius of the ground check circle
    public LayerMask groundLayer;       // LayerMask to specify which layers should be considered ground

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
        if (Input.GetKeyDown(KeyCode.Space) && (isPlayerGrounded))
        {
            Jump();
        }

        // Set the isGrounded parameter in the animator
        playerAnimator.SetBool("isPlayerGrounded", isPlayerGrounded);
    }

    void MovePlayer()
    {
        Vector2 movement = new Vector2(movementSpeed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = movement;
    }

    void Jump()
    {
        // apply jump force to player game object
        playerRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // set jump trigger in animator
        playerAnimator.SetTrigger("jump");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with an item
        ItemInterface item = collision.GetComponent<ItemInterface>();

        // If the item is not null (i.e. the player collides with an item), collect the item
        if (item != null)
        {
            item.CollectItem();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
