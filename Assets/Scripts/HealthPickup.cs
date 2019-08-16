using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            PlayerSounds playerSounds = other.GetComponent<PlayerSounds>();
            if (playerHealth.GetHealth() <= 99.9f)
            {
                playerHealth.RestoreHealth(50.0f);
                playerSounds.PlayHealthPickupSound();
                Destroy(transform.gameObject);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
