using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private void Start() {
        print("initial hit points: " + hitPoints);
    }
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damageAmmount) {
        BroadcastMessage("OnDamageTaken"); //STRING REFERENCE
        hitPoints -= damageAmmount;
        print("hit points: " + hitPoints);
        if (hitPoints <= 0) {
            print("I is dead...");
            Destroy(gameObject);
        }
    }
}