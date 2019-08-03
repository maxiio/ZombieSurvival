using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    AudioSource zombieAudioSource;
    [SerializeField] AudioClip[] zombieAttackClips;

    [SerializeField] AudioCounter audioCounter;

    [SerializeField] float zombieAttackBuffer = 3.0f;

void Start()
{
    zombieAudioSource = GetComponent<AudioSource>();
    audioCounter.setLastZombieNoise(Time.time);

}
    public void PlayZombieAttack()
    {
        float currentTime = Time.time;
        if (currentTime - audioCounter.lastZombieNoise >= zombieAttackBuffer || audioCounter.lastZombieNoise == 0)
        {
            //if longer than buffer, play the sound
            if (!zombieAudioSource.isPlaying)
            {
                System.Random random = new System.Random();
                int randomClipIndex = random.Next(0, zombieAttackClips.Length);
                zombieAudioSource.clip = zombieAttackClips[randomClipIndex];
                zombieAudioSource.PlayOneShot(zombieAttackClips[randomClipIndex]);
                audioCounter.setLastZombieNoise(Time.time);
            }
        } 
    }

}
