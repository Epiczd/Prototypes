using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed the player moves
    [SerializeField] private float moveSpeed = 10f;

    //How high the player jumps
    [SerializeField] private float jumpForce = 8f;

    //Checks if the player is grounded
    private bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();

        print(isGrounded);
    }

    //Method that allows the player to move
    void Movement()
    {
        //A/D or Left/Right arrow to move the player left and right
        float x = Input.GetAxis("Horizontal");

        //Moves the player when the player inputs movement
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * x);
    }

    void Jump()
    {
        //If the player presses space, and is grounded, they will jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //Checks when the player enters a collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player is colliding with the ground, isGrounded is true
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    //Checks when the player exits a collider
    void OnCollisionExit2D(Collision2D collision)
    {
        //If the player is colliding with the ground, isGrounded is false
        if(collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
