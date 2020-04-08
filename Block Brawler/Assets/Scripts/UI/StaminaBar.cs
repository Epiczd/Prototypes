using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    //The players stamina bar
    [SerializeField] private Slider staminaBar;

    //The gradient of the stamina bar
    [SerializeField] private Gradient staminaGradient;

    //Fill of the stamina bar
    [SerializeField] private Image fill;

    //Set's the max stamina
    public void SetMaxStamina(float stamina)
    {
        staminaBar.maxValue = stamina;
        staminaBar.value = stamina;

        fill.color = staminaGradient.Evaluate(1f);
    }

    //Set's the current stamina
    public void SetStamina(float stamina)
    {
        staminaBar.value = stamina;

        fill.color = staminaGradient.Evaluate(staminaBar.normalizedValue);
    }
}
