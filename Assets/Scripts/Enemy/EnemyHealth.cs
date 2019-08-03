using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public Transform player;

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

    public void SetDifficulty(DifficultyLevel level) {
        if (level == DifficultyLevel.Easy)
        {
            hitPoints = hitPoints * .8f;
        }
        if (level == DifficultyLevel.Hard)
        {
            hitPoints = hitPoints * 1.8f;
        }
        Debug.Log("Difficulty set to " + level + " my hitpoints are now " + hitPoints);
    }

    //todoo: ontakedamage notify nearby enemies that player is engaged...
    public bool IsDead() 
    {
        return isDead;
    }
    private void Die()
    {
        if (isDead) return;
        //tell patrol to stop
        GetComponent<Patrol>().StopPatroling();
//        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<LootDrop>().DropLoot(gameObject.transform.position);
        isDead = true;
        GetComponent<MiniMapComponent>().TurnOffTracking();
        GetComponent<Animator>().SetBool("die", true);

    }
}