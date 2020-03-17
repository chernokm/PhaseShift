using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsCutscene : MonoBehaviour
{
	#region cameras
	[SerializeField]
	private Camera artCameraField;
	[SerializeField]
	private Camera designCamera;
	[SerializeField]
	private Camera programmingCamera;
	[SerializeField]
	private Camera QAcamera;
	[SerializeField]
	private Camera soundCamera;
	[SerializeField]
	private Camera uiuxCamera;
	#endregion

	[SerializeField]
	private Image flash;
	[SerializeField]
	private Canvas endCanvas;

	[SerializeField]
	private AudioSource teleporter;

	private int CameraStep;
	private bool artCam1isDone;

    // Start is called before the first frame update
    void Start()
    {
		endCanvas.enabled = false;
		flash.enabled = false;
		RunCutscene();
    }

	private void RunCutscene()
	{
		if(CameraStep == 0) //design camera
		{
			artCameraField.enabled = false;
			designCamera.enabled = true;
			programmingCamera.enabled = false;
			QAcamera.enabled = false;
			soundCamera.enabled = false;
			uiuxCamera.enabled = false;
			StartCoroutine(Countdown());
		}
		else if(CameraStep == 1) //art camera 1
		{
			artCameraField.enabled = true;
			designCamera.enabled = false;
			programmingCamera.enabled = false;
			QAcamera.enabled = false;
			soundCamera.enabled = false;
			uiuxCamera.enabled = false;
			StartCoroutine(Countdown());
		}
		else if (CameraStep == 2) //programming camera
		{
			artCameraField.enabled = false;
			designCamera.enabled = false;
			programmingCamera.enabled = true;
			QAcamera.enabled = false;
			soundCamera.enabled = false;
			uiuxCamera.enabled = false;
			StartCoroutine(Countdown());
		}
		else if (CameraStep == 3) // QA camera
		{
			artCameraField.enabled = false;
			designCamera.enabled = false;
			programmingCamera.enabled = false;
			QAcamera.enabled = true;
			soundCamera.enabled = false;
			uiuxCamera.enabled = false;
			StartCoroutine(Countdown());
		}
		else if (CameraStep == 4) // Sound camera
		{
			artCameraField.enabled = false;
			designCamera.enabled = false;
			programmingCamera.enabled = false;
			QAcamera.enabled = false;
			soundCamera.enabled = true;
			uiuxCamera.enabled = false;
			StartCoroutine(Countdown());
		}
		else if (CameraStep == 5) // UI/UX camera
		{
			artCameraField.enabled = false;
			designCamera.enabled = false;
			programmingCamera.enabled = false;
			QAcamera.enabled = false;
			soundCamera.enabled = false;
			uiuxCamera.enabled = true;
			StartCoroutine(Countdown());
		}
		else if (CameraStep == 6) // Thank you message
		{
			artCameraField.enabled = false;
			designCamera.enabled = true;
			programmingCamera.enabled = false;
			QAcamera.enabled = false;
			soundCamera.enabled = false;
			uiuxCamera.enabled = false;
			endCanvas.enabled = true;
			StartCoroutine(Countdown());
		}
		else if (CameraStep == 7) // Thank you message
		{
			SceneManager.LoadScene(0);
		}
	}

	IEnumerator Countdown()
	{
		yield return new WaitForSeconds(6);
		CameraStep++;
		StartCoroutine(Flash());
		RunCutscene();
	}

	public IEnumerator Flash()
	{
		flash.enabled = true;
		teleporter.Play();
		yield return new WaitForSeconds(0.05f);
		flash.enabled = false;
	}
}
