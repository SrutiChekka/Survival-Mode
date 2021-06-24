using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody myRigidbody;

    public CharacterController characterController;
    public Transform cam;

    public float playerSpeed = 10f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform bulletPos;
    public BulletBehaviour bullet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AimTowardsMouse();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerDirection = new Vector3(horizontal, 0, vertical).normalized;

        if(playerDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(playerDirection.x, playerDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
        }
    }

    private void AimTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out var hitInfo))
        {
            var direction = hitInfo.point - transform.position;
            direction.y = 0;
            direction.Normalize();
            transform.forward = direction;
        }
    }
}
