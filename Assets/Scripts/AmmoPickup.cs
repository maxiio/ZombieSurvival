﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmmount = 5;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Ammo>().IncreaseAmmo(ammoType, ammoAmmount); 
            Destroy(gameObject);
        }
    }
}
