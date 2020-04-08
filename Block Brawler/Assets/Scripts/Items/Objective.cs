using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : ObjectiveChecker
{
    //Checkmark for completing the objective
    [SerializeField] private Image checkMark;

    //Checks if the objective is required or not
    [SerializeField] private bool requiredObjective;

    // On Start, the checkmark, and button are disabled
    void Start()
    {
        checkMark.enabled = false;
    }

    //Checks for collision with the trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        /* If the player collects the objective,
         * the objective is completed, and the checkmark is enabled,
         * the gameobject is also disabled
         */
        if (collision.CompareTag("Player"))
        {
            if (requiredObjective)
            {
                requiredObjectivesCompleted++;
                checkMark.enabled = true;
                gameObject.SetActive(false);
            }
            else
            {
                checkMark.enabled = true;
                gameObject.SetActive(false);
            }
        }
    }
}
