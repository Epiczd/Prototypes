using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : Coin
{
    //The players coins displayed in the HUD
    [SerializeField] private Text coinDisplay;

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    //Updates the amount of coins the player has
    void UpdateDisplay()
    {
        coinDisplay.text = "x " + playerCoins;
    }
}
