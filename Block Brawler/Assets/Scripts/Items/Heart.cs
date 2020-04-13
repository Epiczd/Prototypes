using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PlayerHealth
{
    //The heart
    [SerializeField] private GameObject heart;

    //Checks for collision with the trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        /* If the player collects a heart,
         * The player will restore one health, and the heart will disapear
         */
        if (collision.CompareTag("Player"))
        {
            currentHealth++;
            heart.SetActive(false);
        }
    }
}
