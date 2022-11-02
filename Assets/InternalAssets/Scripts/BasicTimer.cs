using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class BasicTimer : MonoBehaviour
{
    public bool startTimer;
    public TMP_Text TimerText;
    public int timeRemaining = 10;

    void Update ()
    {
        StartCoroutine(Countdown());    
    }

    IEnumerator Countdown () 
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            TimerText.SetText(timeRemaining.ToString());
            Debug.Log('countdown: ' + timeRemaining.ToString());
        }
    } 

}