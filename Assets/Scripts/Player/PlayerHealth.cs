using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float health = 100f;
    DeathHandler playerDeath;
    public Slider HealthBar;

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
        Debug.Log("TakeDamage called with " + damageAmmount + " damage");
        health -= damageAmmount;
        Debug.Log("player health now: " + health);
        HealthBar.value = health;

        if (health <= 0)
        {
            KillPlayer();
        }
    }

    public float GetHealth()
    {
        return health;
    }

    public void RestoreHealth(float healthAmmount) 
    {
        health += healthAmmount;
        if (health >= 100.0f)
        {
            health = 100.0f;
        }
        HealthBar.value = health;
    }

    private void KillPlayer()
    {
        Debug.Log("Player has died");
        GetComponent<DeathHandler>().HandleDeath();
    }
}
