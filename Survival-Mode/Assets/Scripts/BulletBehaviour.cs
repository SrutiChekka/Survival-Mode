using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody myRigidbody;
    public float bulletDamage = 10f;
    public float bulletSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
    }

    private void Movement()
    {
        myRigidbody.velocity = new Vector3(0, 0, bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();
        if(damagable != null)
        {
            damagable.TakeDamage(bulletDamage);
        }
    }
}
