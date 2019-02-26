using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfwayTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;

    public GameObject LapTimerBox;

    void OnTriggerEnter(Collider other)
    {
        HalfwayTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    }
}
