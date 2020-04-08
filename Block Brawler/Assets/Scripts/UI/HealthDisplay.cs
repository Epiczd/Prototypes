using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : PlayerHealth
{
    //Array containing all the hearts
    [SerializeField] private Image[] heart;

    //On start, all the hearts are enabled
    void Start()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            heart[i].enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    //Updates the health display when player takes damage
    void UpdateDisplay()
    {
        switch (currentHealth)
        {
            case 2:
                heart[2].enabled = false;
                heart[1].enabled = true;
                heart[0].enabled = true;
                break;
            case 1:
                heart[1].enabled = false;
                heart[0].enabled = true;
                break;
            case 0:
                for (int i = 0; i < heart.Length; i++)
                {
                    heart[i].enabled = true;
                }
                break;
        }
    }
}
