using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{

    public GameObject LanOnlineUI;
    public GameObject LanUI;
    public GameObject OnlineUI;

    public void LanButtonPress()
    {
        LanOnlineUI.gameObject.SetActive(false);
        LanUI.gameObject.SetActive(true);
    }

    public void OnlineButtonPress()
    {
        LanOnlineUI.gameObject.SetActive(false);
        OnlineUI.gameObject.SetActive(true);
    }

    public void ReturnButtonPress()
    {
        LanOnlineUI.gameObject.SetActive(true);
        LanUI.gameObject.SetActive(false);
        OnlineUI.gameObject.SetActive(false);
    }

}
