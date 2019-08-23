using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmmount = 5;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            if (ammoType == AmmoType.Key)
            {
                other.GetComponent<PlayerSounds>().PlayKeyPickupSound();
                other.GetComponent<KeyRing>().StoreKey();

            } 
            else
            {
                other.GetComponent<PlayerSounds>().PlayReloadSound();
            }
            other.GetComponent<Ammo>().IncreaseAmmo(ammoType, ammoAmmount); 
            Destroy(transform.parent.gameObject);
        }
    }
}
