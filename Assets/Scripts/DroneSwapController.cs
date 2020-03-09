using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneSwapController : MonoBehaviour
{
    [SerializeField]
    private Image droneSwapPrompt;

    [SerializeField]
    private GameObject labTrigger;
    [SerializeField]
    private GameObject worldTrigger;

    [SerializeField]
    private bool isInLab;
    [SerializeField]
    private bool isInWorld;

    private void Start()
    {
        droneSwapPrompt.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isInLab == true && isInWorld == false)
        {
            droneSwapPrompt.enabled = false;
        }
        else if (isInLab == false && isInWorld == true)
        {
            droneSwapPrompt.enabled = true;
        }

    }
}
