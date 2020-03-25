using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private AudioSource axeSwing;

    [SerializeField] private Animator axeAnimator;

    private float timeBtwAttack = 0f;

    // Update is called once per frame
    void Update()
    {
        SwingAxe();

        while (timeBtwAttack <= 1f)
        {
            timeBtwAttack -= Time.deltaTime * 2.5f;
            break;
        }

        if (timeBtwAttack <= 0f)
        {
            timeBtwAttack = 0f;
            axeAnimator.SetBool("Attacking", false);
        }
    }

    //Lets the player swing the axe
    void SwingAxe()
    {
        if (Input.GetButtonDown("Attack") && timeBtwAttack == 0f)
        {
            axeSwing.Play();
            axeAnimator.SetBool("Attacking", true);
            timeBtwAttack++;
        }
    }
}
