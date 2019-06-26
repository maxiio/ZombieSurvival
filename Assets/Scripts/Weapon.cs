using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        bool didHit = Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range);
        if (didHit) {
            print("Hit " + hit.transform.name);
        }

    }
}
