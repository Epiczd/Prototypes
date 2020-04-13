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

    //Checks for entering the collision
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player is colliding with the ground, isGrounded is true
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }    
    }

    //Checks for exiting the collision
    void OnTriggerExit2D(Collider2D collision)
    {
        //If the player is no longer colliding with the ground, isGrounded is false
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }    
    }
}
