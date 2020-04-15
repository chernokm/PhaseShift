using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDroneUse : MonoBehaviour
{
    [Header("When player teleports to this location, can they use the drone")]
    [SerializeField] private bool canUseDrone = true;

    public static event System.Action<bool> OnDroneAccessChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) OnDroneAccessChange(canUseDrone);
    }
}
