using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    //Sound of the axe swinging
    [SerializeField] private AudioSource axeSwing;

    //Animator, that plays the axe animation
    [SerializeField] private Animator axeAnimator;

    //Blade of the axe
    [SerializeField] private Collider axeBlade;

    //Amount of damage dealt by the weapon (for some reason, this deals double damage?)
    [SerializeField] private float damage;

    //Time in between each attack
    private float timeBtwAttack = 0f;

    //On start, damage is cut in half
    private void Start()
    {
        damage /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        SwingAxe();

        //Time between attack will decrease, after each attack
        while (timeBtwAttack <= 1f)
        {
            timeBtwAttack -= Time.deltaTime * 2.5f;
            break;
        }

        if (timeBtwAttack <= 0f)
        {
            axeBlade.enabled = false;
            timeBtwAttack = 0f;
            axeAnimator.SetBool("Attacking", false);
        }
    }

    //Lets the player swing the axe
    void SwingAxe()
    {
        //If the player presses left mouse, they will swing the axe
        if (Input.GetButtonDown("Attack") && timeBtwAttack == 0f)
        {
            axeBlade.enabled = true;
            axeSwing.Play();
            axeAnimator.SetBool("Attacking", true);
            timeBtwAttack++;
        }
    }

    //If the axe hits an enemy, the enemy will take damage
    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.transform.GetComponent<EnemyHealth>();

            enemy.TakeDamage(damage);
        }
    }
}
