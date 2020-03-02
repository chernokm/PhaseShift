using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwap : MonoBehaviour
{
	//These are the cameras
	[SerializeField]
	private GameObject playerCamera;
	[SerializeField]
	private GameObject droneCamera;

	private bool isInPlayerEyes;
	private bool isInDroneEyes;

	private void Start()
	{
		isInPlayerEyes = true;
		isInDroneEyes = false;
	}

	private void Update()
	{
		CheckTransition();
	}

	private void CheckTransition()
	{
		if (Input.GetButtonDown("DroneAccess") && isInPlayerEyes == true && isInDroneEyes == false)
		{
			isInPlayerEyes = false;
			isInDroneEyes = true;
			playerCamera.SetActive(false);
			droneCamera.SetActive(true);
		}
		else if (Input.GetButtonDown("DroneAccess") && isInDroneEyes == true && isInPlayerEyes == false)
		{
			isInPlayerEyes = true;
			isInDroneEyes = false;
			playerCamera.SetActive(true);
			droneCamera.SetActive(false);
		}
	}
}
