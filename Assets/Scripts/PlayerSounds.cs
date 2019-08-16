using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class PlayerSounds : MonoBehaviour {
     public AudioClip walkSound;

    [SerializeField] AudioClip reloadClip;
    [SerializeField] AudioClip healthPickupClip;
     public float footstepDelayWalking;
     public float footstepDelayRunning;

     float footstepDelay;
 
     private float nextFootstep = 0;
 
    private void Start() {
        footstepDelay = footstepDelayWalking;
    }

    public void PlayReloadSound()
    {
        GetComponent<AudioSource>().PlayOneShot(reloadClip);
    }

    public void PlayHealthPickupSound()
    {
        GetComponent<AudioSource>().PlayOneShot(healthPickupClip);
    }

    public void SetFootstepsRunning(bool isRunning)
    {
        if (isRunning)
        {
            footstepDelay = footstepDelayRunning;
        }
        else
        {
            footstepDelay = footstepDelayWalking;
        }
    }
     void Update () {
         if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)
             || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)) {
             nextFootstep -= Time.deltaTime;
             if (nextFootstep <= 0) {
                 GetComponent<AudioSource>().PlayOneShot(walkSound, 0.7f);
                 nextFootstep += footstepDelay;
             }
         }
     }
 }