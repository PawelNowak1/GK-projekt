using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI endTimerText;

    private int coinCounter;
    private float startTime;
    private bool isActive;

    void Start ()
    {
        coinCounter = 0;
        startTime = Time.time;
        isActive = true;
    }

    void Update()
    {
        if(isActive){
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");

            if(seconds.Length > 1)
            {
                timerText.text = minutes + ":" + seconds;
            }
            else
            {
                timerText.text = minutes + ":0" + seconds;
            }
            
        }
    }

    public void AddCoin()
    {
        coinCounter += 1;
        coinText.text = coinCounter.ToString();
    }

    public void FinishMap()
    {
        isActive = false;
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        if (seconds.Length > 1)
        {
            endTimerText.text = minutes + ":" + seconds;
        }
        else
        {
            endTimerText.text = minutes + ":0" + seconds;
        }
    }
}
