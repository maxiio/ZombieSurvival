using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] AudioClip fireWeaponClip;
    [SerializeField] GameObject hitImpact;
    [SerializeField] float weaponRecoil = 10;
    [SerializeField] float recoilDelay = .025f;

    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    [SerializeField] TextMeshProUGUI ammoText;

    AudioSource weaponAudioSource;

    bool canShoot = true;

    public float maxRecoil = 50f;
    public float recoilDecreaseSpeed = 2;
 
    float currentRecoil = 0;

    bool isRecoil = false;

    private void OnEnable() {
        canShoot = true; //fix bug where swapping weapons, player could game the system
    }
    private void Start() {
        weaponAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {        
        DisplayAmmo();
        
        if (isRecoil) { Recoil(); }

        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(FireWeapon());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetAmmoCount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    //todo: Make recticle different color if the current weapon is in range

    IEnumerator FireWeapon()
    {
        canShoot = false;
        Debug.Log("ammo count = " + ammoSlot.GetAmmoCount(ammoType));
        if (ammoSlot.GetAmmoCount(ammoType) > 0)
        {
            StartFiringSequence();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void StartFiringSequence()
    {
        PlayMuzzleFlash();
        PlayWeaponAudio();
        ProcessRaycast();
        ammoSlot.ReduceAmmo(ammoType);
        Invoke("AddRecoil", recoilDelay);
        RemoveRecoil();
    }

    private void PlayWeaponAudio()
    {
        weaponAudioSource.clip = fireWeaponClip;
        weaponAudioSource.PlayOneShot(fireWeaponClip);
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
