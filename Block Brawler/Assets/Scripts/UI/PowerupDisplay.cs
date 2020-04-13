using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PowerupDisplay : Powerup
{
    /* Fist Key (Will Add More Later)
     * 0 - Normal Fist
     * 1 - Rocket Fist
     */

    //Determines witch fist is active
    [SerializeField] private Image[] activeFist;

    [SerializeField] private Text timerText;

    /* On Start, the normal fist is active, 
     * and all other fists are disabled.
     */
    void Start()
    {
        activeFist[0].enabled = true;

        for (int i = 1; i < activeFist.Length; i++)
        {
            activeFist[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
        print(powerTime);
    }

    //Updates the display
    void UpdateDisplay()
    {
        //Switch that determines the active powerup
        switch (nameOfPower)
        {
            //When there is no powerup active
            default:
                activeFist[0].enabled = true;

                for (int i = 1; i < activeFist.Length; i++)
                {
                    activeFist[i].enabled = false;
                }
                break;
            //When the Rocket Fist powerup is active
            case "Rocket Fist":
                if (hasPower && powerTime > 0)
                {
                    powerTime -= Time.deltaTime;
                    timerText.text = powerTime.ToString("f0");
                    activeFist[0].enabled = false;
                    activeFist[1].enabled = true;
                }
                else
                {
                    timerText.text = " ";
                    activeFist[0].enabled = true;

                    for (int i = 1; i < activeFist.Length; i++)
                    {
                        activeFist[i].enabled = false;
                    }
                    hasPower = false;
                    powerTime = timePowerLasts;
                }
                break;
        }
    }
}
