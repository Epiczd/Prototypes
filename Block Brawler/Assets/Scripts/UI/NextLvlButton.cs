using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLvlButton : MonoBehaviour
{
    //The Button that takes you to the next nevel
    [SerializeField] private Button nextLvlButton;

    //The Next Level
    [SerializeField] private string nextLvl;

    //Adds the listener for the button on start
    void Start()
    {
        nextLvlButton.onClick.AddListener(OnClick);
    }

    //Checks for the button to be clicked
    void OnClick()
    {
        //When the button is clicked, it will load the next level
        SceneManager.LoadScene(nextLvl);
    }
}
