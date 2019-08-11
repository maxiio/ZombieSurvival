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
            Debug.Log("Hit health pickup.");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth.GetHealth() <= 99.9f)
            {
                Debug.Log("restoring hp.");
                playerHealth.RestoreHealth(50.0f);
                Destroy(transform.gameObject);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
