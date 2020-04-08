using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveChecker : MonoBehaviour
{
    //The required amount of objectives
    [SerializeField] private int requiredObjectives;

    //Button that takes player to the next level
    [SerializeField] private GameObject nextLvlButton;

    //Amount of required objectives completed
    protected static int requiredObjectivesCompleted;

    //On Start, the next level button is disabled
    void Start()
    {
        nextLvlButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckObjectives();
    }

    //Checks if all required objectives are complete
    void CheckObjectives()
    {
        /* When the player completes all required objectives for this level,
         * They will be done with the level, and the button to take them to the next level will appear
         */
        if(requiredObjectivesCompleted == requiredObjectives)
        {
            nextLvlButton.SetActive(true);
        }
    }
}
