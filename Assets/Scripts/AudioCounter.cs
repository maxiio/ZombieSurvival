using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TimeData", menuName = "Time Data", order = 51)]

public class AudioCounter : ScriptableObject
{
    public float clock;

    public float lastZombieNoise
    {
        get
        {
        return clock;
        }
    }

    public void setLastZombieNoise(float lastAttackNoise)
    {
        clock = lastAttackNoise;
    }
}
