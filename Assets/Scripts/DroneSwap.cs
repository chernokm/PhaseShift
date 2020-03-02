using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwap : MonoBehaviour
{
	//These are the cameras
	[SerializeField]
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController playerObject;
	private Camera playerCam;
	[SerializeField]
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController droneObject;
	private Camera droneCam;

	private bool isInPlayerEyes = true;

	private void Start()
	{
		droneObject.enabled = false;
		playerCam = playerObject.GetComponentInChildren<Camera>();
		droneCam = droneObject.GetComponentInChildren<Camera>();
		droneCam.enabled = false;		
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
					EnableDroneDisablePlayer();
					break;
				case false:
					DisableDroneEnablePlayer();
					break;
			}
		}
	}

	private void DisableDroneEnablePlayer()
	{
		droneObject.enabled = false;
		playerObject.enabled = true;
		isInPlayerEyes = true;
		droneCam.enabled = false;
		playerCam.enabled = true;
	}

	private void EnableDroneDisablePlayer()
	{
		droneObject.enabled = true;
		playerObject.enabled = false;
		droneCam.enabled = true;
		playerCam.enabled = false;
		isInPlayerEyes = false;
	}
}
