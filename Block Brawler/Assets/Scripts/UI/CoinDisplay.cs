using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : Coin
{
    //The players coins displayed in the HUD
    [SerializeField] private TextMeshProUGUI coinDisplay;

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
        print(playerCoins);
    }

    //Updates the amount of coins the player has
    void UpdateDisplay()
    {
        coinDisplay.text = "x " + playerCoins;
    }
}
