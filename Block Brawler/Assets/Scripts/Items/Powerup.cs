using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //The powerup you get from collecting it in game
    [SerializeField] private GameObject powerUp;

    //Time the powerup lasts
    [SerializeField] protected float timePowerLasts;

    //Name of the powerup
    [SerializeField] protected string nameOfPower;

    //Used in HUD
    public static float powerTime;

    //Determines if the player has the power up
    public static bool hasPower = false;

    //Used in other scripts that can't inherit from powerup
    public static string powerName;

    /* On Start, powerTime is set equal to timePowerLasts,
     * And powername is set equal to nameOfPower
     */
    void Start()
    {
        powerTime = timePowerLasts;
        powerName = nameOfPower;
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
            powerUp.SetActive(false);
        }
    }
}
