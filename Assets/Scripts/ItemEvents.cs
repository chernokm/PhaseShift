using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEvents : MonoBehaviour
{
    public static int pickupsCollected = 0;
    public Text interactText;

    public AudioSource audio;

    [SerializeField] private Material alwaysVisible;
    private Material originalMaterial;
    private MeshRenderer itemRenderer;

	
    private void Start()
    {
        this.tag = "Pickup";        
        itemRenderer = GetComponent<MeshRenderer>();
        originalMaterial = itemRenderer.material;
        DroneSwap.IsInDrone += DroneSwap_IsInDrone;
    }

    private void OnDisable()
    {
        DroneSwap.IsInDrone -= DroneSwap_IsInDrone;
    }
    private void DroneSwap_IsInDrone(bool obj)
    {
        if (obj)
        {
            itemRenderer.material = alwaysVisible;
        }
        else
        {
            itemRenderer.material = originalMaterial;
        }
    }



    public void ShowUIPrompt()
    {
        interactText.text = "[ Press F to pick up ]";
    }

    private void OnTriggerExit(Collider other)
    {
        interactText.text = "";
    }

    public void Pickup()
    {
        audio.Play();
        Destroy(gameObject);
        interactText.text = "";
        pickupsCollected += 1;
    }

}
