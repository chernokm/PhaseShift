﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MissionSelector : MonoBehaviour
{
	#region teleporterControl
	[SerializeField]
	private GameObject teleporterLight;
	[SerializeField]
	private GameObject teleporterParticles;
	[SerializeField]
	private GameObject teleporterTrigger;
	#endregion

	#region HUD control
	[SerializeField]
	private Canvas terminalCanvas;
	[SerializeField]
	private Canvas HUDcanvas;
	[SerializeField]
	private GameObject primaryObjective;
	[SerializeField]
	private Text interactionText;
	//[SerializeField]
	//private Text missionResponse;
	#endregion

	public FirstPersonController fpsController;
	private bool isMenuOpen = false;
	private bool isPaused = false;

	[SerializeField]
	private Text objectiveText; //"PrimaryObjectiveText" on AssignementSelectorCanvas (e.g.: Collect X mushrooms)

	private void OnEnable()
	{
		PauseScreen.OnPause += PauseScreen_OnPause;
	}

	private void PauseScreen_OnPause(bool obj)
	{
		isPaused = obj;
	}

	private void Start()
	{
		objectiveText.text = $"PRIMARY: Collect {GameObject.FindGameObjectsWithTag("Pickup").Length} Zetamelaphin Mushrooms"; //harcoded for mushrooms at the moment
		terminalCanvas.enabled = false;
		primaryObjective.SetActive(false);
		teleporterLight.SetActive(false);
		teleporterParticles.SetActive(false);
		teleporterTrigger.SetActive(false);
		this.tag = "Mission Select";
	}

	public void ShowUIPrompt()
	{
		interactionText.text = "Press [F] to access missions";
	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetButtonDown("Interact"))
		{
			OpenMenu();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		interactionText.text = "";
	}

	public void OpenMenu()
	{
		isMenuOpen = true;
		fpsController.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		interactionText.text = "";
		HUDcanvas.enabled = false;
		terminalCanvas.enabled = true;
	}

	public void CloseMenu()
	{
		isMenuOpen = false;
		if (!isPaused) fpsController.enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		HUDcanvas.enabled = true;

		terminalCanvas.enabled = false;
		interactionText.text = "";
	}

	public void ChooseMission()
	{
		//missionResponse.text = "Mission selected - Teleporter active" + "\n" + "Collect 4 Zetamelaphin Mushrooms";
		primaryObjective.SetActive(true);
		teleporterLight.SetActive(true);
		teleporterParticles.SetActive(true);
		teleporterTrigger.SetActive(true);
		CloseMenu();
	}
}
