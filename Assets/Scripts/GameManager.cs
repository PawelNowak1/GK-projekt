using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI endTimerText;
    public TextMeshProUGUI endCoinText;

    private int coinCounter;
    private float startTime;
    private float currentTime;
    private bool isActive;

    void Start ()
    {
        coinCounter = 0;
        startTime = Time.time;
        isActive = true;
    }

    public bool isGameActive()
    {
        return isActive;
    }

    public int GetCoins()
    {
        return coinCounter;
    }

    void Update()
    {
        if(isActive){
            currentTime = Time.time;
            float t = currentTime - startTime;

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
        if (isActive)
        {
            coinCounter += 1;
            coinText.text = coinCounter.ToString();
        }
    }

    public void FinishMap()
    {
        endCoinText.text = coinCounter.ToString();
        isActive = false;
        float t = currentTime;

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
