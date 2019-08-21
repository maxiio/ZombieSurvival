using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public Transform player;

    bool isDead = false;

    [SerializeField] ZombieCounter counter;
    private void Start() {

    }
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damageAmmount) {
        BroadcastMessage("OnDamageTaken"); //STRING REFERENCE
        hitPoints -= Random.Range(damageAmmount/2, damageAmmount);
        if (hitPoints <= 0) {
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
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<LootDrop>().DropLoot(gameObject);
        isDead = true;
        GetComponent<MiniMapComponent>().TurnOffTracking();
        GetComponent<Animator>().SetBool("die", true);
        counter.DecrementEnemies();
    }
}