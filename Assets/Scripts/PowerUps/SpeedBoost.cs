using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    public float thrust;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            FixedUpdate();
        }
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * thrust);
    }
}
