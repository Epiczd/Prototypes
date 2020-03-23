using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed the player moves
    private float moveSpeed = 20f;

    //How high the player will jump
    [SerializeField] private float jumpForce = 100f;

    //Determines if the player is grounded
    private bool isGrounded;

    //Sound effect played when player jumps
    [SerializeField] private AudioSource jumpSound;

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        Jump();

        //If the player is sprinting, the movespeed will increase
        if(Input.GetButton("Sprint") && isGrounded)
        {
            moveSpeed = 40f;
        }
        else
        {
            moveSpeed = 20f;
        }
    }

    //Updates the players position, when the player moves
    void UpdateMovement()
    {
        //Uses WASD or arrow keys to move
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //If the player presses W/S or Up/Down, they will move forward/backward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * z);

        //If the player presses A/D or Left/Right, they will move left/right
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * x);
    }

    //Updates the players position, when the player jumps
    void Jump()
    {
        //If the player presses space, and is grounded, they will jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0f), ForceMode.Impulse);
            jumpSound.Play();
        }
    }

    //Checks if the player is on the ground
    void OnCollisionEnter(Collision collision)
    {
        //If the player is on the ground, isGrounded is true
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    //Checks when the player is NOT on the ground
    void OnCollisionExit(Collision collision)
    {
        //If the player is no longer on the ground, isGrounded is false
        if(collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
