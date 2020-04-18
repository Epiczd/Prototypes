using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //The Key
    [SerializeField] private GameObject key;

    //How many keys the player has
    public static int playerKeys;

    //Amount of keys at the start of the level
    public static int keysAtStart;

    //On Start, keysAtStart are set equal to the players current amount of keys
    void Start()
    {
        keysAtStart = playerKeys;
    }

    //Checks for collision with the trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        /* If the player collects a key,
         * the players key counter goes up, and the key is disabled
         */
        if (collision.CompareTag("Player"))
        {
            playerKeys++;
            key.SetActive(false);
        }
    }
}
