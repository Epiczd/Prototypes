using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //Number of buttons pushed
    protected static int buttonsPushed;

    //On start, the buttons pushed is zero
    void Start()
    {
        buttonsPushed = 0;
    }

    //Checks for entering the trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        /* When the player pushes the button,
         * The number of buttonsPushed increases,
         * and the button is disabled
         */
        if (collision.CompareTag("Player"))
        {
            buttonsPushed++;
            gameObject.SetActive(false);
        }
    }
}
