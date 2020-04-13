using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandCheck : MonoBehaviour
{
    //Checks if the player can stand or not
    protected static bool canStand = true;

    //Checks for collision with the trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player is under a wall, they cannot stand
        if (collision.CompareTag("Wall"))
        {
            canStand = false;
        }
    }

    //Checks for collision exiting the trigger
    void OnTriggerExit2D(Collider2D collision)
    {
        //If the player is NOT under a wall, they can stand
        if (collision.CompareTag("Wall"))
        {
            canStand = true;
        }
    }
}
