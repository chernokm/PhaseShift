using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCANarea : MonoBehaviour
{
	[SerializeField] private bool displayScanDevice = true;
	[SerializeField] private string scanAreaTextToDisplay = "Example Area";
 
	[SerializeField]
	private GameObject scanDevice;
	[SerializeField]
	private TMPro.TextMeshPro remainingSamplesText;

	[SerializeField]
	private Text scanDeviceDisplay;

	private int numberOfCollectiblesInArea = 0;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
		{
			numberOfCollectiblesInArea++; // Dynamically sets how many pickups in this area TODO Won't decrement
			other.gameObject.GetComponent<ItemEvents>().OnPickup += OnItemPickup;
		}

		if (other.CompareTag("Player"))
		{
			scanDeviceDisplay.text = scanAreaTextToDisplay;
			UpdateItemsLeftText();

			if (displayScanDevice)
			{
				scanDevice.SetActive(true);				
			}

			else
			{
				scanDevice.SetActive(false);
			}
		}
	}

	private void OnItemPickup()
	{
		numberOfCollectiblesInArea--;
		UpdateItemsLeftText();
	}

	private void UpdateItemsLeftText()
	{
		remainingSamplesText.text = numberOfCollectiblesInArea.ToString();
	}
}
