using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float health = 100f;
    DeathHandler playerDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmmount) 
    {
       // Debug.Log("TakeDamage called with " + damageAmmount + " damage");
        health -= damageAmmount;
      //  Debug.Log("health now: " + health);

        if (health <= 0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Debug.Log("Player has died");
        GetComponent<DeathHandler>().HandleDeath();
    }
}
