using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    bool isDead = false;

    private void Start() {

    }
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damageAmmount) {
        BroadcastMessage("OnDamageTaken"); //STRING REFERENCE
        hitPoints -= damageAmmount;
        print("hit points: " + hitPoints);
        if (hitPoints <= 0) {
            print("I is dead...");
            Die();
            //Destroy(gameObject);
        }
    }

    public bool IsDead() 
    {
        return isDead;
    }
    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetBool("die", true);
    }
}