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
    [SerializeField] float weaponRecoil = 10;
    [SerializeField] float recoilDelay = .025f;

    [SerializeField] Ammo ammoSlot;

    bool canShoot = true;

    public float maxRecoil = 50f;
    public float recoilDecreaseSpeed = 2;
 
    float currentRecoil = 0;

    bool isRecoil = false;

    void Update()
    {        
        if (isRecoil) { Recoil(); }

        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(FireWeapon());
        }
    }

//todo: Make recticle different color if the current weapon is in range

    IEnumerator FireWeapon()
    {
        canShoot = false;
        Debug.Log("ammo count = " + ammoSlot.GetAmmoCount());
        if (ammoSlot.GetAmmoCount() > 0)
        {
            StartFiringSequence();
        }
        yield return new WaitForSeconds(timeeBetweenShots);
        canShoot = true;
    }

    private void StartFiringSequence()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
        ammoSlot.ReduceAmmo();
        Invoke("AddRecoil", recoilDelay);
        RemoveRecoil();
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

    private void AddRecoil()
     {
        isRecoil =  true;
        currentRecoil += weaponRecoil;
     }

     public void RemoveRecoil()
     {
        isRecoil =  false;
        currentRecoil = 0;
     }


    private void Recoil()
    {
        currentRecoil = Mathf.Clamp (currentRecoil, 0, maxRecoil);
         //decrease recoil all the time
        currentRecoil -= Time.deltaTime * recoilDecreaseSpeed;
         //set camera rot to recoil amount
        Vector3 recoilRot = new Vector3(currentRecoil, 0, 0);
        Camera.main.transform.eulerAngles = Camera.main.transform.eulerAngles - recoilRot;
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitImpact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .15f);
    }
}
