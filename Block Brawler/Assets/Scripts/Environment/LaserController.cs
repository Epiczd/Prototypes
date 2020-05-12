using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : Switch
{
    //The lasers
    [SerializeField] private GameObject[] lasers;

    // Update is called once per frame
    void Update()
    {
        UpdateLasers();
    }

    //Updates the lasers
    void UpdateLasers()
    {
        //When the buttons are pushed, lasers will be turned off
        switch (buttonsPushed)
        {
            default:
                for (int i = 0; i < lasers.Length; i++)
                {
                    lasers[i].SetActive(true);
                }
                break;
            case 1:
                lasers[0].SetActive(false);
                break;
            case 2:
                lasers[1].SetActive(false);
                break;
        }
    }
}
