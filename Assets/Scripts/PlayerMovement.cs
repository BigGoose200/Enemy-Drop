using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // how fast the player goes
    private float horizontal; // controls horizontal axis
    public float jumpForce; // how high the player jumps
    public bool grounded = false; // checks to see if player is touching ground
    public GameObject groundCheck = null; // slot for the ground checker
    private Rigidbody2D MyRb; // need a body to jump

    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>(); //connect ref to rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        // gives the player horizontal movement
        horizontal = Input.GetAxisRaw("Horizontal");
        MyRb.velocity = new Vector2(horizontal * speed, MyRb.velocity.y);

        // checks to see if the player and groundCheck are touching a platform
        if (Physics2D.Linecast(transform.position, groundCheck.transform.position))
        {
            grounded = true; // allows the player to jump
        }
        else // runs while player is in the air
        {
            grounded = false; // prevents the player from jumping
        }

        //if the player presses space while grounded, he or she jumps
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }
}