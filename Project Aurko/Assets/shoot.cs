using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Vector3 movementDirection;
    public GameObject projectilePrefab;
    public float launchVelocity = 700f;
    public GameObject player;
    Vector3 vec;

    private GameObject currentProjectile;

    void Start()
    {
       
    }

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

         movementDirection = new Vector3(horizontalInput + 10, 5.0f, verticalInput + 10);
        movementDirection.Normalize();


        vec = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        if (Input.GetButtonDown("Fire1") && currentProjectile == null)
        {
            ShootProjectile();
        }

        if (Input.GetButtonDown("Fire2") && currentProjectile != null)
        {
            player.transform.position = currentProjectile.transform.position;
            Destroy(currentProjectile);
            currentProjectile = null;
        }
    }

    void ShootProjectile()
    {
        currentProjectile = Instantiate(projectilePrefab, vec + movementDirection, Quaternion.identity);
        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * launchVelocity);
        }
    }
}
