using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartControl : MonoBehaviour
{
    Rigidbody rb;
   
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;

    public GameObject FL;
    public GameObject FR;
    public GameObject BL;
    public GameObject BR;

    public float topSpeed = 250f;
    public float maxTorque = 200f;
    public float maxSteerAngle = 45f;
    public float currentSpeed;
    public float maxBrakeTorque = 2200;

    private float Forward;
    private float Turn;
    private float Brake;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

     void FixedUpdate()
    {
        Forward = Input.GetAxis("Vertical");
        Turn = Input.GetAxis("Horizontal");
        Brake = Input.GetAxis("Jump");

        wheelFL.steerAngle = maxSteerAngle * Turn;
        wheelFR.steerAngle = maxSteerAngle * Turn;

        currentSpeed = 2 * 22 / 7 * wheelBL.radius * wheelBL.rpm * 60 / 1000;

        if (currentSpeed < topSpeed)
        {
            wheelBL.motorTorque = maxTorque * Forward;
            wheelBR.motorTorque = maxTorque * Forward;
        }

        wheelBL.brakeTorque = maxBrakeTorque * Brake;
        wheelBR.brakeTorque = maxBrakeTorque * Brake;
        wheelFL.brakeTorque = maxBrakeTorque * Brake;
        wheelFR.brakeTorque = maxBrakeTorque * Brake;
    }

     void Update()
    {
        Quaternion flq;
        Vector3 flv;
        wheelFL.GetWorldPose(out flv, out flq);
        FL.transform.position = flv;
        FL.transform.rotation = flq;

        Quaternion blq;
        Vector3 blv;
        wheelBL.GetWorldPose(out blv, out blq);
        BL.transform.position = blv;
        BL.transform.rotation = blq;

        Quaternion frq;
        Vector3 frv;
        wheelFR.GetWorldPose(out frv, out frq);
        FR.transform.position = frv;
        FR.transform.rotation = frq;

        Quaternion brq;
        Vector3 brv;
        wheelBR.GetWorldPose(out brv, out brq);
        BR.transform.position = brv;
        BR.transform.rotation = brq;
    }
}
