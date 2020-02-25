using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    [SerializeField]
    private Image frame1;
    [SerializeField]
    private Image frame2;
    [SerializeField]
    private Image frame3;
    [SerializeField]
    private Text speakingText;

    private int lineCount;

    // Start is called before the first frame update
    void Start()
    {
        frame2.enabled = false;
        frame3.enabled = false;
        speakingText.text = "";
        CutsceneOperator();
    }

    private void CutsceneOperator()
    {
        if(lineCount == 0)
        {
            speakingText.text = "The year is 2265, and our planet…. is dying.";
            StartCoroutine(Countdown());
        }
        else if(lineCount == 1)
        {
            speakingText.text = "Desperate for survival, we took to the stars.";
            StartCoroutine(Countdown());
        }
        else if (lineCount == 2)
        {
            frame2.enabled = true;
            speakingText.text = "Equipped with our patented Quantum Realm Transporter, our drones were sent to planets far beyond our solar system, looking for resources to ensure our survival.";
            StartCoroutine(Countdown());
        }
        else if (lineCount == 3)
        {
            speakingText.text = "We detected a compound called ZMP in many plant species; we believe we can use this to give us the support we need.";
            StartCoroutine(Countdown());
        }
        else if (lineCount == 4)
        {
            frame3.enabled = true;
            speakingText.text = "Using our Transporters to send workers planet-side in seconds, we began bringing those resources home.";
            StartCoroutine(Countdown());
        }
        else if (lineCount == 5)
        {
            speakingText.text = "That’s where you step in. Get your suit on, we have work to do.";
            StartCoroutine(Countdown());
        }
        else if(lineCount == 6)
        {
            SceneManager.LoadScene(2);
        }
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(3);
        lineCount++;
        CutsceneOperator();
    }
}
