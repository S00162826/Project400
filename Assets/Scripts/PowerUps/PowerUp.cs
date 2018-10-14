using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{

    public Image powerUpImage;

    void Start()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            powerUpImage.gameObject.SetActive(true);
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            powerUpImage.gameObject.SetActive(false);
        }
    }
}
