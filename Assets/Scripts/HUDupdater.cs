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

    private void Start()
	{
        anim = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        primaryObjectiveText.text = "Zetamelaphin Mushrooms";
		primaryObjectiveNumber.text = "0/4";
	}

	private void Update()
	{
		UpdateObjectives();
	}

	private void UpdateObjectives()
	{
		if(ItemEvents.mushroomAmount == 0)
		{
			primaryObjectiveNumber.text = "0/4";
		}
		else if (ItemEvents.mushroomAmount == 1)
		{
			primaryObjectiveNumber.text = "1/4";
		}
		else if (ItemEvents.mushroomAmount == 2)
		{
			primaryObjectiveNumber.text = "2/4";
		}
		else if (ItemEvents.mushroomAmount == 3)
		{
			primaryObjectiveNumber.text = "3/4";
		}
		else if (ItemEvents.mushroomAmount == 4)
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
