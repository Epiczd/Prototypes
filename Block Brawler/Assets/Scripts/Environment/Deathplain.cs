using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathplain : PlayerHealth
{
    //Player transform
    [SerializeField] private Transform player;

    //Checks for collision with the trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player enters the death plain, they will die
        if (collision.CompareTag("Player"))
        {
            Death();
        }
    }

    //When the player falls into the death plain, they will die and respawn
    void Death()
    {
        lives--;
        player.transform.position = playerSpawn.transform.position;
        currentHealth = maxHealth;
    }
}
