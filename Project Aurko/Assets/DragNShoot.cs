using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragNshoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    public GameObject projectilePrefab;
    public float launchVelocity = 700f;
    public GameObject player;
    public float forceMultiplier = 3;
    Vector3 movementDirection;

    private GameObject currentProjectile;

    void Start()
    {
    }

    void Update()
    {
        movementDirection = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Input.GetButtonDown("Fire2") && currentProjectile != null)
        {
            player.transform.position = currentProjectile.transform.position;
            Destroy(currentProjectile);
            currentProjectile = null;
        }
    }

    private void OnMouseDown()
    {
        Destroy(currentProjectile);
        currentProjectile = null;
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos - mousePressDownPos);
    }


    void Shoot(Vector3 Force)
    {

        currentProjectile = Instantiate(projectilePrefab, transform.forward + movementDirection, Quaternion.identity);
        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
        }
    }



}