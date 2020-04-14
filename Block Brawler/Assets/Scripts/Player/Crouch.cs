using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : StandCheck
{
    //Player when standing
    [SerializeField] private Transform playerNormal;

    //Checks for standing
    [SerializeField] private Transform playerColliderT;

    // Update is called once per frame
    void Update()
    {
        Crouching();
    }

    //Checks for the player to crouch
    void Crouching()
    {
        if (Input.GetButton("Down"))
        {
            transform.localScale = new Vector3(playerNormal.localScale.x, 0.5f, playerNormal.localScale.z);
            playerColliderT.localScale = new Vector3(1f, 2f, 1f);
        }
        else if(canStand)
        {
            transform.localScale = new Vector3(playerNormal.localScale.x, 1f, playerNormal.localScale.z);
            playerColliderT.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
