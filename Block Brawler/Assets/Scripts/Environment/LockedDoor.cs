using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Key
{
    //Checks for collision with a door
    void OnCollisionEnter2D(Collision2D collision)
    {
        /* If the player collides with a door, and the player has a key,
         * The door would unlock, and the player could proceed
         */
        if(collision.collider.tag == "Player" && playerKeys > 0)
        {
            playerKeys--;
            gameObject.SetActive(false);
        }
    }
}
