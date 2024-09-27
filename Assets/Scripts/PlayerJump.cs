using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // how high the player jumps
    public float jumpThrust = 8.0f; 
    private Rigidbody2D rigidBody2D;
    private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        // get the rigidbody component
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // look for the space key to jump and check if the player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            // player 'jumps' by adding force to the y-axis
            // ForceMode2D.Impulse adds an instant force to the rigidbody
            rigidBody2D.AddForce(Vector2.up * jumpThrust, ForceMode2D.Impulse);

            // player is no longer on the ground
            isOnGround = false;
        }
    }

    // check if the player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
