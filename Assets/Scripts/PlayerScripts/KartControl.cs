using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartControl : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 centreOfMass = new Vector3(0,0,0);

    public WheelCollider[] wc;

    public int accelerationLength;

    public bool brakeAllowed;

    public float maxSpeed = 2500f;
    public float maxSteer = 25f;
    public float maxBrake = 10000f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreOfMass;
    }

     void Update()
    {
        Handbrake();
    }

    void FixedUpdate()
    {
        for (int i = 0; i < accelerationLength; i++)
        {
            wc[i].motorTorque = Input.GetAxis("Vertical") * maxSpeed;
        }

        wc[0].steerAngle = Input.GetAxis("Horizontal") * maxSteer;
        wc[1].steerAngle = Input.GetAxis("Horizontal") * maxSteer;
    }

    void Handbrake()
    {
        if (Input.GetKey(KeyCode.C))
        {
            brakeAllowed = true;
        }
        else
        {
            brakeAllowed = false;
        }

        if (brakeAllowed)
        {
            for (int i = 0; i < accelerationLength; i++)
            {
                wc[i].brakeTorque = maxBrake;
                wc[i].motorTorque = 0;
            }
        }
        else if (!brakeAllowed && Input.GetButton("Vertical") == true)
        {
            for (int i = 0; i < accelerationLength; i++)
            {
                wc[i].brakeTorque = 0;
            }
        }
    }
}
