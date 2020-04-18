using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDisplay : Key
{
    //Amount of keys the player has, displayed in the HUD
    [SerializeField] private Text keyDisplay;


    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    //Updates the display when needed
    void UpdateDisplay()
    {
        keyDisplay.text = "x " + playerKeys;
    }
}
