using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation : MonoBehaviour
{
    //Name of the current level (MUST BE EXACT!!!)
    [SerializeField] private string nameOfLvl;

    //Current level the player is on
    public static string currentLevel = "Level1";

    //On Start, the player's current level is set
    void Start()
    {
        currentLevel = nameOfLvl;
    }

}
