using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //The powerup you get from collecting it in game
    [SerializeField] private GameObject powerUp;

    //Time the powerup lasts
    [SerializeField] private float timePowerLasts;

    [SerializeField] private PowerName nameOfP;

    //Used in HUD
    public static float powerTime;

    //Determines if the player has the power up
    public static bool hasPower = false;

    //Used in other scripts that can't inherit from powerup
    public static PowerName powerName;

    //Max time powerup will last
    protected static float maxTime;

    /* On Start, powerTime is set equal to timePowerLasts,
     * And powername is set equal to nameOfPower
     */
    void Start()
    {
        print(nameOfP);
        maxTime = powerTime;
    }

    //Checks for collision with the trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        /* If the player collects the power up,
         * The player will be able to use the power up,
         * and the object will dissapear
         */
        if (collision.CompareTag("Player"))
        {
            hasPower = true;
            powerName = nameOfP;
            powerTime = timePowerLasts;
            powerUp.SetActive(false);
        }
    }
}

//Contains all possible powerups
public enum PowerName
{
    RocketFist,
    DoubleFist,
}

