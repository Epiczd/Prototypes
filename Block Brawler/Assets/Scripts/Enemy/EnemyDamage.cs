using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : PlayerHealth
{
    //Amount of damage the enemy deals
    [SerializeField] private float damage = 1f;

    //Checks for collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the enemy attacks the player, they will take damage
        if(collision.collider.tag == "Player")
        {
            currentHealth -= damage;
        }
    }
}
