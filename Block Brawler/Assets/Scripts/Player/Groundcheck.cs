using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : PlayerMovement
{

    //Keeps the groundcheck in place
    void Update()
    {
        Vector3 savedPosition = transform.position;
        transform.position = savedPosition;
    }

    //Checks when the player enters a collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player is colliding with the ground, isGrounded is true
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    //Checks when the player exits a collider
    void OnTriggerExit2D(Collider2D collision)
    {
        //If the player is colliding with the ground, isGrounded is false
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
