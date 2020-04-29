using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDupdater : MonoBehaviour
{
	[SerializeField]
	private Text primaryObjectiveText;
	[SerializeField]
	private Text primaryObjectiveNumber;

	public static int maxPickups; //number of objects Tagged "Pickup" in scene

	private void Start()
	{
		primaryObjectiveText.text = "Zetamelaphin Mushrooms";
		maxPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;
	}

	private void Update()
	{
		//Can put this in its own method
		primaryObjectiveNumber.text = ItemEvents.pickupsCollected + "/" + maxPickups;
		if (ItemEvents.pickupsCollected >= maxPickups)
		{
			primaryObjectiveText.text = "Return to Teleporter";
			primaryObjectiveNumber.text = "";
		}
	}

}
