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
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player is colliding with the ground, isGrounded is true
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }    
    }

    //Checks for exiting the collision
    void OnCollisionExit2D(Collision2D collision)
    {
        //If the player is NOT colliding with the ground, isGrounded is false
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
