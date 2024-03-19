using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;


public class move : MonoBehaviour
{
    public Vector3 jump;
    public float speed = 2.0f;
    public GameObject character;
    public Animation anim;
    public bool isGrounded;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * speed, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
