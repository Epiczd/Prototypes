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

    //Amount of ammo in the guns clip
    [SerializeField] private int clip;

    //Amount of ammo in the guns magazine
    [SerializeField] private int magazine;

    //The guns animator
    [SerializeField] private Animator gunAnimator;

    //Reload sound effect
    [SerializeField] private AudioSource reloadSound;

    //The maximum amount of ammo a clip can hold
    private int maxClip;

    //The maximum amount of ammo the player can hold
    private int maxMag;

    //The current clip, displayed in the HUD
    protected static int currentClip;

    //The current mag, displayed in the HUD
    protected static int currentMag;

    //Impact force closeby
    private float impactForceFar = 10f;

    //Impact force faraway
    private float impactForceClose = 100f;

    //Amount of time to reload
    private float reloadTime = 1f;

    //Amount of shots fired
    private int shotsFired = 0;

    //Determines if the player can reload
    private bool reloaded;

    /* On start, the maxClip, and maxMag are set,
     * Based on the values set in the inspector
     */
    void Start()
    {
        maxClip = clip;
        maxMag = magazine;
    }

    //Updates currentClip/Mag, and checks for shooting/reloading
    void Update()
    {
        currentClip = clip;
        currentMag = magazine;

        if (Input.GetButtonDown("Attack") && clip > 0)
        {
            Shooting();
        }

        Reload(true);
    }

    /* When the player fires, by pressing attack (left mouse)
     * A ray cast is shot, and if it hits a target
     * It will deal an appropriate amount of damage,
     * Depending on how far away the target is
     */
    void Shooting()
    {
        muzzleFlash.Play();
        gunShot.Play();
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

        shotsFired++;
        clip--;
    }

    /* If the player's clip is empty,
     * or the player presses R to reload,
     * the gun will start to reload
     */
    void Reload(bool canReload)
    {
        if(magazine <= 0)
        {
            canReload = false;
        }
        else
        {
            canReload = true;
        }

        if(clip <= 0 && canReload == true || Input.GetButtonDown("Reload") && clip < maxClip && canReload == true)
        {
            reloaded = true;
        }

        if(reloaded && reloadTime > 0f)
        {
            reloadTime -= Time.deltaTime * 2.5f;
        }
        else if(reloaded && reloadTime <= 0f)
        {
            reloadTime = 0f;
            reloadSound.Play();
            clip = maxClip;
            magazine -= shotsFired;
            shotsFired = 0;
            reloaded = false;
        }
    }
}
