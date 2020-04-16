using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : Boss
{
    //The players normal camera
    [SerializeField] private GameObject normalCamera;

    //A fixed camera only used during boss fights
    [SerializeField] private GameObject bossCamera;

    //On Start, the normalCamera is active, and the bossCamera is not active
    void Start()
    {
        normalCamera.SetActive(true);
        bossCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LockCamera();
    }

    //Checks if the camera needs locked
    void LockCamera()
    {

        if(bossMode && bossDead == false)
        {
            normalCamera.SetActive(false);
            bossCamera.SetActive(true);
        }
        else
        {
            normalCamera.SetActive(true);
            bossCamera.SetActive(false);
        }
    }
}
