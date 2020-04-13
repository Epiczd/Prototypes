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

    //Sound Effect when punching
    [SerializeField] private AudioSource punchSound;

    //Distance the rocket fist can go
    [SerializeField] private float rocketDistance;

    //Spawn points for the fists
    [SerializeField] private Transform[] fistSpawn;

    //Rocketforce
    [SerializeField] private float rocketForce = 10f;

    //The player's maximum amount of stamina
    private float maxStamina;

    //Determines if the player can attack or not
    private bool canAttack = true;

    //Amount of damage dealt with a punch
    protected static float punchDamage = 5f;

    //Fires the rocket fist
    private bool fired = false;

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

        if(Powerup.hasPower == false)
        {
            //Sets fist in the correct spawn point
            for (int i = 0; i < playersFist.Length; i++)
            {
                playersFist[i].transform.position = fistSpawn[i].position;
            }

            //If the player presses left mouse, or f, they will attack
            if (Input.GetButton("Attack") && facingLeft == false && canAttack)
            {
                playersFist[0].SetActive(true);

                Stamina -= 0.1f;
            }
            else
            {
                playersFist[0].SetActive(false);

                if (Stamina < maxStamina)
                {
                    Stamina += Time.deltaTime * 2.5f;
                }
            }

            if (Input.GetButton("Attack") && facingLeft && canAttack)
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

            //Plays the sound effect when punching
            if (Input.GetButtonDown("Attack"))
            {
                punchSound.Play();
            }
        }
        else
        {
            switch (Powerup.powerName)
            {
                case "Rocket Fist":
                    if(Powerup.powerTime > 0)
                    {
                        if(Input.GetButtonDown("Attack") && facingLeft == false)
                        {
                            playersFist[0].SetActive(true);

                            playersFist[1].SetActive(false);

                            playersFist[0].transform.position = fistSpawn[0].position;

                            fired = true;
                        }

                        if (fired && facingLeft == false)
                        {
                            playersFist[0].transform.Translate(Vector2.right * Time.smoothDeltaTime * rocketForce);
                        }

                        if(Input.GetButtonDown("Attack") && facingLeft)
                        {
                            playersFist[1].SetActive(true);

                            playersFist[0].SetActive(false);

                            playersFist[1].transform.position = fistSpawn[1].position;

                            fired = true;
                        }

                        if(fired && facingLeft)
                        {
                            playersFist[1].transform.Translate(Vector2.left * Time.smoothDeltaTime * rocketForce);
                        }
                    }
                    break;
            }
        }

    }
}
