using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseScreen : MonoBehaviour
{
	[SerializeField]
	private Canvas hudCanvas;
	[SerializeField]
	private Canvas pauseCanvas;

	public static event System.Action<bool> OnPause;

	private bool isPaused = false;

	private void Awake()
	{
		pauseCanvas.enabled = false;
	}

	private void Update()
	{
		CheckIfPaused();
	}

	private void CheckIfPaused()
	{
		if (Input.GetButtonDown("Cancel") && !isPaused)
		{
			hudCanvas.enabled = false;
			pauseCanvas.enabled = true;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			OnPause(true);
            Time.timeScale = 0;
			isPaused = true;
		}
	}

	public void ResumeButton()
	{
		isPaused = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		pauseCanvas.enabled = false;
		hudCanvas.enabled = true;
		OnPause(false);
		Time.timeScale = 1;
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void QuitButton()
	{
		Application.Quit();
	}
}
