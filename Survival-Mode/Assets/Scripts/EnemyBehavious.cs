using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class EnemyBehavious : MonoBehaviour, IDamagable
{
    public ThirdPersonController player;
    public NavMeshAgent enemy;

    public float enemyHitPoints = 100f;

    public float damagePlayer = 10f;

    WaveManager waveManager;

    private void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        player = FindObjectOfType<ThirdPersonController>();
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
            waveManager.EnemyDied();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.TakeLife(damagePlayer);
            //FindObjectOfType<ThirdPersonController>().TakeLife(damagePlayer);
        }
    }
}
