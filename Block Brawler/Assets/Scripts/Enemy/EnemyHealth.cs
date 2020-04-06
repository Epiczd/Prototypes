using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Punch
{
    //Amount of health the enemy has
    [SerializeField] private float health = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Fist")
        {
            health -= 5f;
        }    
    }
}
