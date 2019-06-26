using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameEnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5.0f;

    bool isProvoked = false;

    NavMeshAgent navMeshAgent;
    
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked) {
            EngageTarget();
        } else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }

        if  (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        print("EXTERMINATE!!!");
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}