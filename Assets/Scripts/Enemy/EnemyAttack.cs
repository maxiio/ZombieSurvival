using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] PlayerHealth target;
    [SerializeField] float damage = 40f;
     

    public void AtttackHitEvent() {
        if (target == null) { return;  }
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
