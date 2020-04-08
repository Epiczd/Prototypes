using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : PlayerMovement
{
    //The player's fist (0 is right fist, 1 is left fist)
    [SerializeField] private GameObject[] playersFist;

    //Player's stamina bar
    [SerializeField] private StaminaBar staminaBar;

    //The player's stamina
    [SerializeField] private float Stamina = 5f;

    //The player's maximum amount of stamina
    private float maxStamina;

    //Determines if the player can attack or not
    private bool canAttack = true;

    //Amount of damage dealt with a punch
    protected static float punchDamage = 5f;

    //On start, the player's fist is not drawn, and is disabled
    void Start()
    {
        playersFist[0].SetActive(false);
        playersFist[1].SetActive(false);

        maxStamina = Stamina;
        staminaBar.SetMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        Punching();

        staminaBar.SetStamina(Stamina);

        print(Stamina);

        if(Stamina > 0f)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
    }

    //Checks if the player is punching
    void Punching()
    {
        //If the player presses left mouse, or f, they will attack
        if (Input.GetButton("Attack") && facingLeft == false && canAttack)
        {
            playersFist[0].SetActive(true);

            Stamina -= 0.1f;
        }
        else
        {
            playersFist[0].SetActive(false);
            
            if(Stamina < maxStamina)
            {
                Stamina += Time.deltaTime * 2.5f;
            }
        }

        if(Input.GetButton("Attack") && facingLeft && canAttack)
        {
            playersFist[1].SetActive(true);

            Stamina -= 0.1f;
        }
        else
        {
            playersFist[1].SetActive(false);

            if (Stamina < maxStamina)
            {
                Stamina += Time.deltaTime * 2.5f;
            }
        }
    }
}
