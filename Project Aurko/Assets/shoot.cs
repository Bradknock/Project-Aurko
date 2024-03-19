using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Vector3 movementDirection;
    public GameObject projectilePrefab;
    public float launchVelocity = 700f;
    public GameObject player;


    private GameObject currentProjectile;

    void Start()
    {
       
    }

    void Update()
    {

         movementDirection = new Vector3(transform.position.x, transform.position.y, transform.position.z);


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
        currentProjectile = Instantiate(projectilePrefab, transform.forward + movementDirection, Quaternion.identity);
        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * launchVelocity);
            rb.AddForce(new Vector3(0, 4.0f, 0) * (launchVelocity - 400));
        }
    }
}
