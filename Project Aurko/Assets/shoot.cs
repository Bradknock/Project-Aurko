using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Vector3 s;
    public GameObject projectile;
    public float launchVelocity = 700f;
    public GameObject character;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(launchVelocity, 0, 0));
            if (Input.GetButtonDown("Fire2"))
            {
                character.transform.position = ball.transform.position;
            }
        }
        
    }
}