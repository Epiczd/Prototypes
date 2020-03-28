using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Amount of health the player has
    [SerializeField] private float health;

    //The players healthbar
    [SerializeField] private Healthbar healthBar;

    //The players max health
    private float maxHealth;

    //Current Player Health displayed in the HUD
    protected static float currentPlayerHealth;

    void Start()
    {
        maxHealth = health;
        healthBar.SetMaxHealth(maxHealth);
    }

    //Updates the current player health
    void Update()
    {
        currentPlayerHealth = health;
    }

    //When the player takes damage, they lose health by the amount of damage
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.SetHealth(health);

        if(health <= 0f)
        {
            Death();
        }
    }

    //When the player loses all health, it will die
    void Death()
    {
        SceneManager.LoadScene("GameOver");
    }
}
