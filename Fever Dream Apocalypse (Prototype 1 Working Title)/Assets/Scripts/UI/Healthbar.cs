using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    //The healthbar
    [SerializeField] private Slider healthSlider;

    //The healthbar's gradient
    [SerializeField] private Gradient healthGradient;

    //Fill of the healthbar
    [SerializeField] private Image fill;

    //Sets the max health equal to the sliders max value
    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        fill.color = healthGradient.Evaluate(1f);
    }

    //Sets the healthbar's value, equal to the players health
    public void SetHealth(float health)
    {
        healthSlider.value = health;

        fill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
