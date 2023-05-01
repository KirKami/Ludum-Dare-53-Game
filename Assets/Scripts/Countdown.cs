using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public static Countdown instance;

    public bool hyperdriveState;

    public float secondsTimer;
    public int secondsLeft = 1800;

    public TMP_Text countdownText;

    public Canvas WinScreen;

    private void Awake()
    {
        if(instance == null) instance = this;
    }
    void OnDestroy()
    {
        instance = null;
    }

    void FixedUpdate()
    {
        if(secondsTimer >= 1f)
        {
            secondsTimer -= 1f;
            secondsLeft--;
            UpdateCountdownText();
        }
        else
        {
            secondsTimer += Time.fixedDeltaTime;
        }
        if (hyperdriveState) WinScreen.enabled = true;
    }
    void UpdateCountdownText()
    {
        countdownText.text = (secondsLeft / 60).ToString() + " Days Left";
    }
}
