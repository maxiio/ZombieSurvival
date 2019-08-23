using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class PlayerSounds : MonoBehaviour {
    public AudioClip walkSound;
    public AudioClip walkConcreteSound;

    AudioClip currentWalkSound;

    [SerializeField] AudioClip reloadClip;
    [SerializeField] AudioClip keyPickupSound;
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

    public void PlayKeyPickupSound()
    {
        GetComponent<AudioSource>().PlayOneShot(keyPickupSound);
    }
    public void PlayHealthPickupSound()
    {
        GetComponent<AudioSource>().PlayOneShot(healthPickupClip);
    }

    private void OnCollisionEnter(Collision other) {

        if (other.gameObject.tag == "Ground")
        {
            currentWalkSound = walkSound;
        }
        else if (other.gameObject.tag == "Concrete")
        {
            currentWalkSound = walkConcreteSound;
        }
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
                 GetComponent<AudioSource>().PlayOneShot(currentWalkSound, 0.7f);
                 nextFootstep += footstepDelay;
             }
         }
     }
 }