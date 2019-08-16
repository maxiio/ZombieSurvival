using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameEnemyAI : MonoBehaviour
{

    Transform target;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float chaseRange = 5.0f;
    EnemyHealth health;

    [SerializeField] float chaseSpeed = 3.5f;
    [SerializeField] float soundRange = 5.0f;

    [SerializeField] float idleSpeed = 1.0f;
    bool isProvoked = false;

    EnemySounds sounds;

    private bool nearbySoundPlayed = false;
    NavMeshAgent navMeshAgent;
    
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        sounds = GetComponent<EnemySounds>();
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            return;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= soundRange && !nearbySoundPlayed)
        {
            PlaySounds();
            nearbySoundPlayed = true;
        } 
        if (isProvoked) {
            EngageTarget();
        } 
        else if (distanceToTarget <= chaseRange) {
            if (isPlayerVisible() == true) {
            isProvoked = true;
            }
        }
    }

    private void PlaySounds()
    {
        sounds.PlayZombieAttack();
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
        GetComponent<Animator>().SetBool("attack", true);
        navMeshAgent.speed = idleSpeed;
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
        navMeshAgent.speed = chaseSpeed;

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