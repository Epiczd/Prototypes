using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : SwapWeapons
{
    //Determines which weapon is active
    [SerializeField] private GameObject[] activeWeapon;

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    //Will update the display based on the active weapon
    void UpdateDisplay()
    {
        /* If the primary weapon is active, 
         * the primary weapons info is displayed.
         * If the secondary weapon is active,
         * the secondary weapons info is displayed.
         */
        switch (primaryActive)
        {
            case true:
                activeWeapon[0].SetActive(true);
                activeWeapon[1].SetActive(false);
                break;
            case false:
                activeWeapon[0].SetActive(false);
                activeWeapon[1].SetActive(true);
                break;
        }
    }
}
