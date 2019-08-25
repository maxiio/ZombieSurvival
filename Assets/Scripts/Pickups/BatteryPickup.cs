﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] BatteryLevel myLevel = BatteryLevel.Full;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashlightSystem>().ChargeFlashlight(myLevel);
            PlayerSounds playerSounds = (PlayerSounds)FindObjectOfType(typeof(PlayerSounds));
            playerSounds.PlayBatteryPickupSound();
            Destroy(gameObject);
        }
    }
}
