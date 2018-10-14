using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement variables
    bool disabled;
    bool disablePlayer = false;
    public float moveSpeed = 40000;
    private Vector3 moveVelocity;
    Rigidbody rb;

    //To access objects
    public Camera mainCamera;

    void Start()
    {
        //Finds the objects I want to assign to the variables
        rb = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        //What determines how the player moves
        if (disablePlayer == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            rb.AddForce(new Vector3(horizontal * moveSpeed * Time.deltaTime,
                           0, vertical * moveSpeed * Time.deltaTime));
            rb.velocity = moveVelocity;
        }
    }
}
