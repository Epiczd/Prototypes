using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillDisplay : WaveManager
{
    //The enemies killed, displayed in the hud
    [SerializeField] private TextMeshProUGUI killCounter;

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    //Updates the amount of enemies killed in the hud
    void UpdateDisplay()
    {
        killCounter.text = "Enemies Killed: " + enemiesKilled;
    }
}
