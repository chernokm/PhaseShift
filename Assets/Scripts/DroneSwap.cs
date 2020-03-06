using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneSwap : MonoBehaviour
{
	//These are the cameras
	[SerializeField]
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController playerObject;
	private Camera playerCam;
	[SerializeField]
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController droneObject;
	private Camera droneCam;

    [SerializeField]
    private Canvas hudCanvas;
    [SerializeField]
    private Canvas droneCanvas;
	[SerializeField]
	private DroneMovement droneMovementScript;
	
	private bool isInPlayerEyes = true;

	private void Start()
	{
		droneObject.enabled = false;
		playerCam = playerObject.GetComponentInChildren<Camera>();
		droneCam = droneObject.GetComponentInChildren<Camera>();
		droneCam.enabled = false;
        droneCanvas.enabled = false;
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
        hudCanvas.enabled = true;
        droneCanvas.enabled = false;
		droneMovementScript.enabled = false;
	}

	private void EnableDroneDisablePlayer()
	{
		droneObject.enabled = true;
		playerObject.enabled = false;
		droneCam.enabled = true;
		playerCam.enabled = false;
		isInPlayerEyes = false;
        hudCanvas.enabled = false;
        droneCanvas.enabled = true;
		droneMovementScript.enabled = true;
	}
}
