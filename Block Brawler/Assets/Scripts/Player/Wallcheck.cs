using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallcheck : PlayerMovement
{
    //Keeps wallcheck in place
    void Update()
    {
        Vector3 savedPosition = transform.position;
        transform.position = savedPosition;
    }

    //Checks for collision with trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player is on a wall, onWall is true
        if (collision.CompareTag("Wall"))
        {
            onWall = true;
        }
    }

    //Checks for exiting the trigger
    void OnTriggerExit2D(Collider2D collision)
    {
        //If the player is NOT on a wall, onWall is false
        if (collision.CompareTag("Wall"))
        {
            onWall = false;
        }    
    }
}
