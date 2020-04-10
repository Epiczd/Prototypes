using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : PlayerLives
{
    //The lives counter
    [SerializeField] private TextMeshProUGUI livesCounter;

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    //Updates the lives display
    void UpdateDisplay()
    {
        //Updates the lives counter with the player's current lives
        livesCounter.text = "x " + lives;
    }
}
