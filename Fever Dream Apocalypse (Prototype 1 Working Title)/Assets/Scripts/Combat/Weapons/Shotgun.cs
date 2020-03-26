using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    //Damage dealt at farther away
    [SerializeField] private float minDamage;

    //Damage dealt at close range
    [SerializeField] private float maxDamage;

    //Range the gun can fire
    [SerializeField] private float range;

    //The player's camera
    [SerializeField] private Camera playerCamera;

    //Muzzle Flash from the gun
    [SerializeField] private ParticleSystem muzzleFlash;
    
    //Sound of the gun being fired
    [SerializeField] private AudioSource gunShot;

    //Impact force closeby
    private float impactForceFar = 10f;

    //Impact force faraway
    private float impactForceClose = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Shooting();
            gunShot.Play();
        }
    }

    void Shooting()
    {
        muzzleFlash.Play();


        RaycastHit hit;

        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.distance);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

            if(enemy != null)
            {
                if(hit.distance < 3f)
                {
                    enemy.TakeDamage(maxDamage);
                }
                else
                {
                    enemy.TakeDamage(minDamage);
                }
            }

            if(hit.rigidbody != null)
            {
                if(hit.distance < 3f)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForceClose);
                }
                else
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForceFar);
                }
            }
        }
    }
}
