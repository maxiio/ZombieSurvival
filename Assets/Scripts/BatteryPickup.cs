using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    // Start is called before the first frame update

    FlashlightSystem flashLight;
    [SerializeField] BatteryLevel myLevel = BatteryLevel.Full;

    void Start()
    {
        flashLight = FindObjectOfType<FlashlightSystem>();
        Debug.Log("Battery Start: " + flashLight.name);

    }
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("OnTriggerEnter");
        flashLight.ChargeFlashlight(myLevel);
        Destroy(gameObject);
    }

}
