using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEvents : MonoBehaviour
{
    //Regions subdivided for sake of clarity

    public AudioSource audio = new AudioSource();

    public Text interactText;

    public static int pickupsCollected = 0;

    private void Start()
    {
        this.tag = "Pickup";
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
