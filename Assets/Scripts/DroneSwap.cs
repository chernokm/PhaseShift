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
	public static event System.Action<bool> IsInDrone;
	
	private bool isInPlayerEyes = true;
	private bool droneAccess = false;

	private void OnEnable()
	{
		PauseScreen.OnPause += PauseScreen_OnPause;
		TriggerDroneUse.OnDroneAccessChange += TriggerDroneUse_OnDroneAccessChange;
	}

	private void TriggerDroneUse_OnDroneAccessChange(bool LocationDroneAccess)
	{
		droneAccess = LocationDroneAccess;
	}

	private void PauseScreen_OnPause(bool obj)
	{
		switch (obj)
		{
			case true:
				if (isInPlayerEyes) playerObject.enabled = false;
				else droneObject.enabled = false;
				break;

			case false:
				if (isInPlayerEyes) playerObject.enabled = true;
				else droneObject.enabled = true;
				break;
		}
	}

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
		if (droneAccess)
		{
			if (Input.GetButtonDown("DroneAccess"))
			{
				switch (isInPlayerEyes)
				{
					case true:
						EnableDroneDisablePlayer();
						IsInDrone(true);
						break;
					case false:
						IsInDrone(false);
						DisableDroneEnablePlayer();
						break;
				}
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
