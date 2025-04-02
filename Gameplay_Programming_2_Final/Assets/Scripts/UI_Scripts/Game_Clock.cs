using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Clock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ClockUI;
    [SerializeField] public float Max_Timer;
    private float minutes;
    private float trueSeconds;
    private float miliseconds;
    // Start is called before the first frame update
    void Start()
    {
        minutes = 0;
        trueSeconds = 0;
    }

    public void Reset()
    {
        minutes = 0;
        trueSeconds = 0;
        miliseconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (UI_Manager.Instance.GameStarted)
        {
            miliseconds += Time.deltaTime;
            int seconds = (int)miliseconds % 60;
            if (seconds == 1)
            {
                miliseconds = 0;
                trueSeconds += seconds;
            }
            if (trueSeconds == 60)
            {
                minutes += 1;
                trueSeconds = 0;
            }
            ClockUI.text = minutes + ":" + trueSeconds + ":" + (miliseconds * 10);
            float test = minutes + (trueSeconds / 100);
            if (Max_Timer - minutes == 0)
            {
                UI_Manager.Instance.EndGame("Time's Up!");
            }
        }
    }
}
