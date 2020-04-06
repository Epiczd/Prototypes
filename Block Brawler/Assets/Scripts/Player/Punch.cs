using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : PlayerMovement
{
    //The player's fist (0 is right fist, 1 is left fist)
    [SerializeField] private GameObject[] playersFist;

    //On start, the player's fist is not drawn, and is disabled
    void Start()
    {
        playersFist[0].SetActive(false);
        playersFist[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Punching();
    }

    //Checks if the player is punching
    void Punching()
    {
        //If the player presses left mouse, or f, they will attack
        if (Input.GetButton("Attack") && facingLeft == false)
        {
            playersFist[0].SetActive(true);
        }
        else
        {
            playersFist[0].SetActive(false);
        }

        if(Input.GetButton("Attack") && facingLeft)
        {
            playersFist[1].SetActive(true);
        }
        else
        {
            playersFist[1].SetActive(false);
        }
    }
}
