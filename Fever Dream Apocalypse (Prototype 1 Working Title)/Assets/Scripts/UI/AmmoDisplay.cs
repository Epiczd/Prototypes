using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplay : Shotgun
{
    //Amount of ammo displayed on screen
    [SerializeField] private TextMeshProUGUI ammoText;

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    //Updates the amount of ammo on screen
    void UpdateDisplay()
    {
        ammoText.text = currentClip + "/" + currentMag;
    }
}
