﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] int ammoCount = 10;

    public int GetAmmoCount()
    {
        return ammoCount;
    }

    public void ReduceAmmo()
    {
        ammoCount--;
    }
}
