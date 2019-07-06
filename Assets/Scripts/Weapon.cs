using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] float timeeBetweenShots = 0.5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitImpact;

    [SerializeField] Ammo ammoSlot;

    bool canShoot = true;

    void Update()
    {        
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(FireWeapon());
        }
    }

    IEnumerator FireWeapon()
    {

        canShoot = false;
        Debug.Log("ammo count = " + ammoSlot.GetAmmoCount());
        if (ammoSlot.GetAmmoCount() > 0) {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceAmmo();
        }
        yield return new WaitForSeconds(timeeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range);
        if (didHit) {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; } 
            target.TakeDamage(damage);
        } else {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitImpact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .5f);
    }
}
