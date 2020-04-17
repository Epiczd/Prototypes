﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //The Coin
    [SerializeField] private GameObject coin;

    //Coin Sound Effect
    [SerializeField] private AudioSource coinSound;

    //Amount of coins the player has
    protected static int playerCoins;

    //Checks for collision with the trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        /* If the player collects a coin,
         * the players coin counter goes up,
         * and the coin is disabled
         */
        if (collision.CompareTag("Player"))
        {
            coinSound.Play();
            playerCoins++;
            coin.SetActive(false);
        }    
    }
}
