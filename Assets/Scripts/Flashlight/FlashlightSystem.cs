using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{

    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 0.1f;

    [SerializeField] float minSpotAngle = 40.0f;

    Light myLight;

    float minLightIntensity = 0.0f;
    [SerializeField] float maxLightIntensity;
    [SerializeField] float maxSpotAngle;

    //starting value for the lerp
    float newIntensity;
    float newSpotAngle;


    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.intensity = maxLightIntensity;
        myLight.spotAngle =  maxSpotAngle;
        newIntensity = maxLightIntensity;
        newSpotAngle = maxSpotAngle;
    }

    // Update is called once per frame
    void Update()
    {
        DecraseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float intensityAmmount)
    {
        myLight.intensity += intensityAmmount;
    }

    public void ChargeFlashlight(BatteryLevel level) 
    {
        if (level == BatteryLevel.Full)
        {
            
        }
        if (level == BatteryLevel.Half)
        {

        }
        if (level == BatteryLevel.Full) 
        {
            myLight.spotAngle = maxSpotAngle;
            myLight.intensity = maxLightIntensity;
            newIntensity = maxLightIntensity;
            newSpotAngle = maxSpotAngle;
        }
    }
    private void DecreaseLightIntensity()
    {
            if (myLight.intensity >= minLightIntensity)
            {
                myLight.intensity = newIntensity;
                newIntensity -= lightDecay * Time.deltaTime;
            }


    }

    private void DecraseLightAngle()
    {
        if (myLight.spotAngle >= minSpotAngle)
        {
            myLight.spotAngle = newSpotAngle;
            newSpotAngle -= angleDecay * Time.deltaTime;
        }

    }
}
