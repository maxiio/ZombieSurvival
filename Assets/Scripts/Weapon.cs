using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;

    void Start()
    {
    //Camera.GetComponent(AudioListener).enabled = false;
    print("AudioListeners " + Resources.FindObjectsOfTypeAll(typeof(AudioListener)).Length);

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[]) {
            print("GameObject: " + go.name );

        }
        int count = Camera.allCameras.Length;
        print("We've got " + count + " cameras");
    

    var listener = GameObject.FindObjectOfType<AudioListener>();
    listener.enabled = false;

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            PlayMuzzleFlash();
            ProcessRaycast();
        }
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
            print("Hit " + hit.transform.name);
            // TODO: add hit effeect
            //todo: call method on enemy health
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; } 
            target.TakeDamage(damage);

        } else {
            return;
        }
    }
}
