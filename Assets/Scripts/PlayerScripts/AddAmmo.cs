using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmo : MonoBehaviour
{
    public GunController theGun;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AmmoCrate")
        {
            //ammo.Play();
            theGun.ammo = theGun.ammo + 5;
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
