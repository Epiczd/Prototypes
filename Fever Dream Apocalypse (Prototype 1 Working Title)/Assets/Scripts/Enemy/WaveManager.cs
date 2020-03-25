using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //How many enemies have been killed
    protected static int enemiesKilled = 0;

    //Array containing all the waves
    [SerializeField] private GameObject[] waves;

    // Update is called once per frame
    void Update()
    {
        UpdateWaves();
    }

    //Updates the current wave of enemies, when the player defeats a wave
    void UpdateWaves()
    {
        switch (enemiesKilled)
        {
            case 0:
                waves[0].SetActive(true);
                waves[1].SetActive(false);
                break;
            case 2:
                waves[1].SetActive(true);
                break;
        }
    }
}
