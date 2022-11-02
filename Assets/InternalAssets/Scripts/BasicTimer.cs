using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicTimer : MonoBehaviour
{
    public bool startTimer;
    public TMP_Text TimerText;
    public int timeRemaining = 10;

    void Start ()
    {
        StartCoroutine(Countdown());    
    }

    IEnumerator Countdown () 
    {
        while (true)
        {
            TimerText.SetText(timeRemaining.ToString());
            timeRemaining--;

            if (timeRemaining == 0)
            {
                yield break;
            }

            Debug.Log("countdown: " + timeRemaining.ToString());
            yield return new WaitForSeconds(1);
        }
    } 
}