using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed the player moves
    [SerializeField] private float moveSpeed = 10f;

    //How high the player jumps
    [SerializeField] private float jumpForce = 8f;

    //Jump Sound Effect
    [SerializeField] private AudioSource jumpSound;

    //Checks if the player is facing left or right
    protected static bool facingLeft = false;

    //Checks if the player is grounded
    protected static bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    //Method that allows the player to move
    void Movement()
    {
        //A/D or Left/Right arrow to move the player left and right
        float x = Input.GetAxis("Horizontal");

        //Moves the player when the player inputs movement
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * x);

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            facingLeft = false;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            facingLeft = true;
        }
    }

    void Jump()
    {
        //If the player presses space, and is grounded, they will jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpSound.Play();
        }
    }

}
