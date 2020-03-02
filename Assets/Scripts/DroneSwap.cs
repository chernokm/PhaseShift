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

	private bool isInPlayerEyes = true;

	private void Start()
	{
		droneCamera.SetActive(false);
	}

	private void Update()
	{
		CheckTransition();
	}

	private void CheckTransition()
	{
		if (Input.GetButtonDown("DroneAccess"))
		{
			switch (isInPlayerEyes)
			{
				case true:
					playerCamera.SetActive(false);
					droneCamera.SetActive(true);
					isInPlayerEyes = false;
					break;
				case false:
					droneCamera.SetActive(false);
					playerCamera.SetActive(true);
					isInPlayerEyes = true;
					break;
			}
		}
	}
}
