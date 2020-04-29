using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEvents : MonoBehaviour
{
    //Regions subdivided for sake of clarity

    public AudioSource audio = new AudioSource();


    public GameObject mazeDoor;
    #endregion

	#region Item Triggers
	public GameObject mushroomTrigger1;
    public GameObject mushroomTrigger2;
    public GameObject mushroomTrigger3;
    public GameObject mushroomTrigger4;
    public GameObject mushroomTrigger5;

    //public GameObject keycardTrigger1;
    //public GameObject keycardTrigger2;
	#endregion

	#region Items
	public GameObject mushroom1;
    public GameObject mushroom2;
    public GameObject mushroom3;
    public GameObject mushroom4;
    public GameObject mushroom5;

	//public GameObject keycard1;
	//public GameObject keycard2;
	#endregion

	public AudioSource audio;

    [SerializeField] private Material alwaysVisible;
    private Material originalMaterial;
    private MeshRenderer itemRenderer;

	public GameObject thePlayer;

    public Text interactText;

    public static int pickupsCollected = 0;

    private void Start()
    {
        this.tag = "Pickup";        
        itemRenderer = GetComponent<MeshRenderer>();
        originalMaterial = itemRenderer.material;
        DroneSwap.IsInDrone += DroneSwap_IsInDrone;
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
