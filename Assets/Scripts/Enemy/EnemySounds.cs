using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    AudioSource zombieAudioSource;
    [SerializeField] AudioClip zombieAttackClip;
    [SerializeField] AudioClip zombieChaseClip;

    [SerializeField] AudioCounter audioCounter;

    [SerializeField] float zombieAttackBuffer = 3.0f;

/// <summary>
/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.
/// </summary>
void Start()
{
    zombieAudioSource = GetComponent<AudioSource>();
}
    public void PlayZombieAttack()
    {
        float currentTime = Time.time;
        if (currentTime - audioCounter.lastZombieNoise >= zombieAttackBuffer || audioCounter.lastZombieNoise == 0)
        {
            //if longer than buffer, play the sound
            if (!zombieAudioSource.isPlaying && zombieAudioSource.clip.loadState == AudioDataLoadState.Loaded)
            {
                zombieAudioSource.PlayOneShot(zombieAttackClip);
                audioCounter.setLastZombieNoise(Time.time);
            }
        } 
    }
 
     public void PlayChaseSounds()
    {
        // if (!zombieAudioSource.isPlaying && zombieAudioSource.clip.loadState == AudioDataLoadState.Loaded)
        // {
        //     zombieAudioSource.PlayOneShot(zombieChaseClip);
        // }
    }

}
