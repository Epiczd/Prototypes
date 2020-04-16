﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : Boss
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player enters the boss area, bossMode is set to true
        if (collision.CompareTag("Player"))
        {
            bossMode = true;
        }
    }
}
