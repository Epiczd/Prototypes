using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapons : MonoBehaviour
{
    //An array containing all of the players weapons
    [SerializeField] private GameObject[] weapons;

    //Determines if the primary weapon is active
    private bool primaryActive = true;

    // Update is called once per frame
    void Update()
    {
        Swap();
    }

    //Allows the player to swap between primary and secondary weapons
    void Swap()
    {
        if (Input.GetButtonDown("SwapWeapon") && primaryActive)
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
            primaryActive = false;
        }
        else if (Input.GetButtonDown("SwapWeapon") && primaryActive == false)
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            primaryActive = true;
        }
    }
}
