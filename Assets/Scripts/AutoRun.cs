using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRun : MonoBehaviour
{
    public float speed = 3.0f; // set speed of the object
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // get the rigidbody component
        rigidBody = GetComponent<Rigidbody2D>(); 

        // move on the x-axis
        rigidBody.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // continuously move forward on the x-axis at chosen speed
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }
}
