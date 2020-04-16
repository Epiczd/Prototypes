using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    //The bosses healthbar
    [SerializeField] private Slider healthBar;

    //Healthbar Gradient
    [SerializeField] private Gradient healthGradient;

    //Fill of the stamina bar
    [SerializeField] private Image fill;

    //Set's the max health
    public void SetMaxHealth(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        fill.color = healthGradient.Evaluate(1f);
    }

    //Set's the current health
    public void SetHealth(float health)
    {
        healthBar.value = health;

        fill.color = healthGradient.Evaluate(healthBar.normalizedValue);
    }
}
