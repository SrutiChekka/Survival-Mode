using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour, IDamagable
{
    private ThirdPersonController player;

    public float collectableHitPoints = 10f;
    public float addToPlayerHealth = 100f;

    void Start()
    {
        player = FindObjectOfType<ThirdPersonController>();
    }


    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        collectableHitPoints -= damage;
        if (collectableHitPoints <= 0)
        {
            player.GainLife(addToPlayerHealth);
            Destroy(gameObject);
        }
    }
}
