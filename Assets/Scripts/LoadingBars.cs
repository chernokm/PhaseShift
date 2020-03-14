using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class LoadingBars : MonoBehaviour
{
	public int minimum;
	public int maximum;
	public int current;
	public Image mask;

	void GetCurrentFill()
	{
		float currentOffset = current - minimum;
		float maximumOffset = maximum - minimum;
		float fillAmount = currentOffset / maximumOffset;
		mask.fillAmount = fillAmount;
	}

	private void Update()
	{
		GetCurrentFill();
	}

	public void FillProgressBar()
	{
		while (current < maximum)
		{
			StartCoroutine(Countdown());
		}
	}

	IEnumerator Countdown()
	{
		yield return new WaitForSeconds(1);
		current += 10;
		FillProgressBar();
	}
}
