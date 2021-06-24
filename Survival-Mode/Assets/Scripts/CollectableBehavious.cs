using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavious : MonoBehaviour, IDamagable
{
    public float collectableHitPoints = 10f;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        collectableHitPoints -= damage;
        if (collectableHitPoints <= 0)
        {
            //increase score
            Destroy(gameObject);
        }
    }
}
