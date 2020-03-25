using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : PlayerHealth
{
    //Amount of health displayed on the hud
    [SerializeField] private TextMeshProUGUI healthText;


    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    //Displays the amount of health to the hud
    void UpdateHealth()
    {
        healthText.text = "Health: " + currentPlayerHealth;
    }
}
