using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Contains the bosses name/healthbar
    [SerializeField] private GameObject bossInfo;

    //Determines if the boss is dead or alive
    public static bool bossDead = false;

    //Determines if boss mode is active or not
    public static bool bossMode = false;

    //On Start, boss info is disabled
    void Start()
    {
        bossInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ActivateBoss();
    }

    //Activates the boss
    void ActivateBoss()
    {
        /* If the boss is alive, and boss mode is activated,
         * The boss info will be displayed, and the battle will begin.
         * If the boss is killed by the player,
         * Boss mode is deactivated, and the boss info is hidden
         */
        if (bossMode && bossDead == false)
        {
            bossInfo.SetActive(true);
        }
        else if (bossDead)
        {
            bossMode = false;
            bossInfo.SetActive(false);
        }
    }
}
