using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneSwapController : MonoBehaviour
{
    [SerializeField]
    private GameObject droneSwapPrompt;

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
        droneSwapPrompt.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isInLab == true && isInWorld == false)
        {
            droneSwapPrompt.SetActive(false);
        }
        else if (isInLab == false && isInWorld == true)
        {
            droneSwapPrompt.SetActive(true);
        }

    }
}
