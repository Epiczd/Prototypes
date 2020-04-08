using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Amount of health the player has
    [SerializeField] private float health = 3f;

    //The players spawn location
    [SerializeField] private Transform playerSpawn;

    //The current amount of health the player has, displayed in the H.U.D
    protected static float currentHealth;

    //On start, the current health is set to health
    void Start()
    {
        currentHealth = health;
    }

    //When the player takes damage, it subtracts the amount from it's current health
    void Update()
    {
        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    //When the players health is 0, they will die and respawn
    void Death()
    {
        transform.position = playerSpawn.transform.position;
        currentHealth = health;
    }
}
