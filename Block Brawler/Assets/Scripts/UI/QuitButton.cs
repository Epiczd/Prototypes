using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    //The quit button
    [SerializeField] private Button quit;

    //Adds listener for the button
    void Start()
    {
        quit.onClick.AddListener(OnClick);
    }

    //Is executed when the button is clicked
    void OnClick()
    {
        //When this button is clicked, it will close out of the game
        Application.Quit();
    }
}
