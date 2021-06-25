using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    public CharacterController characterController;
    public Transform cam;

    public float playerHitPoints = 100f;

    public float playerSpeed = 10f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform firePoint;
    public Rigidbody bulletPrefab;
    public float launchForce = 200;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        Movement();
        LookAtMouse();
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletInstance.AddForce(firePoint.forward * launchForce);
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (playerDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(playerDirection.x, playerDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
        }
    }

    public void LookAtMouse()
    {
        float yCamera = cam.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yCamera, 0), turnSmoothTime * Time.deltaTime);
    }

    public void TakeLife(float damage)
    {
        playerHitPoints -= damage;
        if (playerHitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GainLife(float life)
    {
        playerHitPoints += life;
    }
}
