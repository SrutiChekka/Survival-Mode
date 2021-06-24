using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class EnemyBehavious : MonoBehaviour, IDamagable
{
    public GameObject player;
    public NavMeshAgent enemy;

    public float enemyHitPoints = 100f;

    void Start()
    {
        
    }


    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if(player)
        {
            enemy.SetDestination(player.transform.position);
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHitPoints -= damage;
        if(enemyHitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }


}
