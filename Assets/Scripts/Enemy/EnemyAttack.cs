using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth target;
    [SerializeField] float damage = 40f;
     

    private void Start() 
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    
    public void AtttackHitEvent() {
        if (target == null) { return;  }
        target.GetComponent<PlayerHealth>().TakeDamage(Random.Range(damage/2, damage));
        target.GetComponent<DamageUI>().ShowDamageUI();
    }
}
