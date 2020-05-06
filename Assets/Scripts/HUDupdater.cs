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
    [SerializeField]
    private AudioClip success;

    Animator anim;
    private AudioSource audio;
    private bool missionComplete;
    private float duration;

	public static int maxPickups;

    private void Start()
	{
        anim = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        primaryObjectiveText.text = "Zetamelaphin Mushrooms";
		maxPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;
	}

	private void Update()
	{
		primaryObjectiveNumber.text = ItemEvents.pickupsCollected + "/" + maxPickups;
		if (ItemEvents.pickupsCollected >= maxPickups)
		{
			missionComplete = true;
			primaryObjectiveText.text = "Return to teleporter";
			primaryObjectiveNumber.text = "";
			anim.SetBool("MissionIsDone", missionComplete);
			//audio.PlayOneShot(success, 1);
			//audio.volume = 0;
		}
	}
}
