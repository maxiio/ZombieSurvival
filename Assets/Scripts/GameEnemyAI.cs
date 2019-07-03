using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameEnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float chaseRange = 5.0f;

    bool isProvoked = false;
    bool isAttacking = false;

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
            if (isPlayerVisible() == true) {
            isProvoked = true;
            }
        }
    }

    public bool isPlayerVisible() {
        Vector3 direction = target.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit)){
            PlayerHealth player = hit.transform.GetComponent<PlayerHealth>();
            if (player == null) { return false; }
        }
        return true;
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
    private void EngageTarget()
    {   
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }

        if  (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        isAttacking = true;
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void ChaseTarget()
    {
        isAttacking = false;
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,  lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}