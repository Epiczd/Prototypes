using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Punch : PlayerMovement
{
    //The player's fist (0 is right fist, 1 is left fist, 2 is up fist, 3 is down fist)
    [SerializeField] private GameObject[] playersFist;

    /* Used whhen the player has double fist active,
     * (0 is right fist, 1 is left fist, 2 is up fist, 3 is down fist)
     */
    [SerializeField] private GameObject[] playerSecondFist;

    //Player's stamina bar
    [SerializeField] private StaminaBar staminaBar;

    //The player's stamina
    [SerializeField] private float Stamina = 5f;

    //Sound Effect when punching
    [SerializeField] private AudioSource punchSound;

    //Distance the rocket fist can go
    [SerializeField] private float rocketDistance;

    //Spawn points for the fists (0 is right fist, 1 is left fist, 2 is up fist, 3 is down fist)
    [SerializeField] private Transform[] fistSpawn;

    //Rocketforce
    [SerializeField] private float rocketForce = 10f;

    //How long a rocket lasts
    [SerializeField] private float rocketTime = 1f;

    //The player's maximum amount of stamina
    private float maxStamina;

    //Determines if the player can attack or not
    private bool canAttack = true;

    //Amount of damage dealt with a punch
    protected static float punchDamage = 5f;

    private bool isAttacking = false;

    //Fires the rocket fist
    private bool fired = false;

    //On start, the player's fist is not drawn, and is disabled
    void Start()
    {
        for (int i = 0; i < playersFist.Length; i++)
        {
            playersFist[i].SetActive(false);
            playerSecondFist[i].SetActive(false);
        }

        maxStamina = Stamina;
        staminaBar.SetMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        Punching();

        staminaBar.SetStamina(Stamina);

        //Plays the sound effect when punching
        if (Input.GetButtonDown("Attack"))
        {
            punchSound.Play();
        }

        if (isAttacking && Stamina > 0)
        {
            Stamina -= Time.deltaTime * 2.5f;
        }
        else
        {
            if (Stamina < maxStamina)
            {
                Stamina += Time.deltaTime * 2.5f;
            }
        }

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
                playerSecondFist[i].SetActive(false);
            }

            switch (playerDirection)
            {
                default:
                    for (int i = 0; i < playersFist.Length; i++)
                    {
                        playersFist[i].SetActive(false);
                    }

                    break;
                case PlayerDirection.Right:

                    //If the player presses left mouse, or f, they will attack
                    if (Input.GetButton("Attack") && canAttack)
                    {
                        playersFist[0].SetActive(true);

                        for (int i = 1; i < playersFist.Length; i++)
                        {
                            playersFist[i].SetActive(false);
                        }

                        isAttacking = true;
                    }
                    else
                    {
                        playersFist[0].SetActive(false);

                        isAttacking = false;
                    }
                    break;
                case PlayerDirection.Left:

                    if (Input.GetButton("Attack") && canAttack)
                    {
                        playersFist[1].SetActive(true);

                        for (int i = 0; i > -1; i--)
                        {
                            playersFist[i].SetActive(false);
                        }
                        
                        for (int i = 2; i < playersFist.Length; i++)
                        {
                            playersFist[i].SetActive(false);
                        }

                        isAttacking = true;
                    }
                    else
                    {
                        playersFist[1].SetActive(false);

                        isAttacking = false;
                    }
                    break;
                case PlayerDirection.Up:
                    if (Input.GetButton("Attack")&& canAttack)
                    {
                        playersFist[2].SetActive(true);

                        for (int i = 1; i > -1; i--)
                        {
                            playersFist[i].SetActive(false);
                        }

                        for (int i = 3; i < playersFist.Length; i++)
                        {
                            playersFist[i].SetActive(false);
                        }

                        isAttacking = true;
                    }
                    else
                    {
                        playersFist[2].SetActive(false);

                        isAttacking = false;
                    }
                    break;
                case PlayerDirection.Down:
                    if (Input.GetButton("Attack") && canAttack)
                    {
                        playersFist[3].SetActive(true);

                        for (int i = 2; i > -1; i--)
                        {
                            playersFist[i].SetActive(false);
                        }

                        isAttacking = true;
                    }
                    else
                    {
                        playersFist[3].SetActive(false);

                        isAttacking = false;
                    }
                    break;
            }
        }
        else
        {
            //Checks which power up is active
            switch (Powerup.powerName)
            {
                //Called if rocket fist is active
                case PowerName.RocketFist:

                    /* If the powerup still has time, it will call this,
                     * And allow the player to fire in any direction they want
                     */
                    if(Powerup.powerTime > 0)
                    {
                        //Checks which direction the player is firing
                        switch (playerDirection)
                        {
                            case PlayerDirection.Right:
                                if (Input.GetButtonDown("Attack"))
                                {
                                    playersFist[0].SetActive(true);

                                    for (int i = 1; i < playersFist.Length; i++)
                                    {
                                        playersFist[i].SetActive(false);
                                    }

                                    playersFist[0].transform.position = fistSpawn[0].position;
                                    
                                    fired = true;
                                }

                                if (fired && rocketTime > 0)
                                {
                                    playersFist[0].transform.Translate(Vector2.right * Time.smoothDeltaTime * rocketForce);
                                    rocketTime -= Time.deltaTime;
                                }
                                else if(rocketTime >= 0f || rocketTime <= 0f && rocketTime < 1f)
                                {
                                    playersFist[0].transform.position = fistSpawn[0].position;
                                    fired = false;
                                    rocketTime += Time.deltaTime;
                                }
                                break;
                            case PlayerDirection.Left:
                                if (Input.GetButtonDown("Attack"))
                                {
                                    playersFist[1].SetActive(true);

                                    for (int i = 0; i > -1; i--)
                                    {
                                        playersFist[i].SetActive(false);
                                    }

                                    for (int i = 2; i < playersFist.Length; i++)
                                    {
                                        playersFist[i].SetActive(false);
                                    }

                                    playersFist[1].transform.position = fistSpawn[1].position;

                                    fired = true;
                                }

                                if (fired)
                                {
                                    playersFist[1].transform.Translate(Vector2.left * Time.smoothDeltaTime * rocketForce);
                                    rocketTime -= Time.deltaTime;
                                }
                                else if (rocketTime >= 0f || rocketTime <= 0f && rocketTime < 1f)
                                {
                                    playersFist[1].transform.position = fistSpawn[1].position;
                                    fired = false;
                                    rocketTime += Time.deltaTime;
                                }
                                break;
                            case PlayerDirection.Up:
                                if (Input.GetButtonDown("Attack"))
                                {
                                    playersFist[2].SetActive(true);

                                    for (int i = 1; i > -1; i--)
                                    {
                                        playersFist[i].SetActive(false);
                                    }

                                    for (int i = 3; i < playersFist.Length; i++)
                                    {
                                        playersFist[i].SetActive(false);
                                    }

                                    playersFist[2].transform.position = fistSpawn[2].position;

                                    fired = true;
                                }

                                if (fired)
                                {
                                    playersFist[2].transform.Translate(Vector2.up * Time.smoothDeltaTime * rocketForce);
                                    rocketTime -= Time.deltaTime;
                                }
                                else if (rocketTime >= 0f || rocketTime <= 0f && rocketTime < 1f)
                                {
                                    playersFist[2].transform.position = fistSpawn[2].position;
                                    fired = false;
                                    rocketTime += Time.deltaTime;
                                }
                                break;
                            case PlayerDirection.Down:
                                if (Input.GetButtonDown("Attack"))
                                {
                                    playersFist[3].SetActive(true);

                                    for (int i = 2; i > -1; i--)
                                    {
                                        playersFist[i].SetActive(false);
                                    }

                                    playersFist[3].transform.position = fistSpawn[3].position;

                                    fired = true;
                                }

                                if (fired)
                                {
                                    playersFist[3].transform.Translate(Vector2.down * Time.smoothDeltaTime * rocketForce);
                                    rocketTime -= Time.deltaTime;
                                }
                                else if (rocketTime >= 0f || rocketTime <= 0f && rocketTime < 1f)
                                {
                                    playersFist[3].transform.position = fistSpawn[3].position;
                                    fired = false;
                                    rocketTime += Time.deltaTime;
                                }
                                break;
                        }
                    }
                    break;

                case PowerName.DoubleFist:
                    /* If the powerup still has time, it will call this,
                     * And allow the player to punch with two fists at once,
                     * This allows for the player to hit enemies farther away, and possibly deal double damage
                     */
                    if (Powerup.powerTime > 0)
                    {
                        //Checks which direction the player is firing
                        switch (playerDirection)
                        {
                            case PlayerDirection.Right:
                                if (Input.GetButton("Attack") && Stamina > 0)
                                {
                                    playersFist[0].SetActive(true);
                                    playerSecondFist[0].SetActive(true);

                                    for (int i = 1; i < playersFist.Length; i++)
                                    {
                                        playersFist[i].SetActive(false);
                                        playerSecondFist[i].SetActive(false);
                                    }

                                    isAttacking = true;
                                }
                                else
                                {
                                    isAttacking = false;
                                    playersFist[0].SetActive(false);
                                    playerSecondFist[0].SetActive(false);
                                }
                                break;
                            case PlayerDirection.Left:
                                if (Input.GetButton("Attack") && Stamina > 0)
                                {
                                    playersFist[1].SetActive(true);
                                    playerSecondFist[1].SetActive(true);

                                    for (int i = 0; i > -1; i--)
                                    {
                                        playersFist[i].SetActive(false);
                                        playerSecondFist[i].SetActive(false);
                                    }

                                    for (int i = 2; i < playersFist.Length; i++)
                                    {
                                        playersFist[i].SetActive(false);
                                        playerSecondFist[i].SetActive(false);
                                    }

                                    isAttacking = true;
                                }
                                else
                                {
                                    isAttacking = false;
                                    playersFist[1].SetActive(false);
                                    playerSecondFist[1].SetActive(false);
                                }
                                break;
                            case PlayerDirection.Up:
                                if (Input.GetButton("Attack") && Stamina > 0)
                                {
                                    playersFist[2].SetActive(true);
                                    playerSecondFist[2].SetActive(true);

                                    for (int i = 1; i > -1; i--)
                                    {
                                        playersFist[i].SetActive(false);
                                        playerSecondFist[i].SetActive(false);
                                    }

                                    for (int i = 3; i < playersFist.Length; i++)
                                    {
                                        playersFist[i].SetActive(false);
                                        playerSecondFist[i].SetActive(false);
                                    }

                                    isAttacking = true;
                                }
                                else
                                {
                                    isAttacking = false;
                                    playersFist[2].SetActive(false);
                                    playerSecondFist[2].SetActive(false);
                                }
                                break;
                            case PlayerDirection.Down:
                                if (Input.GetButton("Attack") && Stamina > 0)
                                {
                                    playersFist[3].SetActive(true);
                                    playerSecondFist[3].SetActive(true);

                                    for (int i = 2; i > -1; i--)
                                    {
                                        playersFist[i].SetActive(false);
                                        playerSecondFist[i].SetActive(false);
                                    }

                                    isAttacking = true;
                                }
                                else
                                {
                                    isAttacking = false;
                                    playersFist[3].SetActive(false);
                                    playerSecondFist[3].SetActive(false);
                                }
                                break;
                        }
                    }
                    break;
            }
        }

    }
}
