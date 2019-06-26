using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    // create public method to reduce hit points by the ammount of damage

    public void TakeDamage(float damageAmmount) {
        hitPoints -= damageAmmount;
        print("hit points: " + hitPoints);
        if (hitPoints <= 0) {
            print("I is dead...");
            Destroy(gameObject);
        }
    }

}
