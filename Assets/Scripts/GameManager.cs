using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUI;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI endTimerText;
    public TextMeshProUGUI endCoinText;

    private int coinCounter;
    private float startTime;
    private float currentTime;
    private bool isActive;
    private GameObject[] healthLabels;

    void Start ()
    {
        coinCounter = 0;
        startTime = Time.time;
        isActive = true;

        GameObject healt1 = GameObject.Find("Unit_1");
        GameObject healt2 = GameObject.Find("Unit_2");
        GameObject healt3 = GameObject.Find("Unit_3");
        GameObject healt4 = GameObject.Find("Unit_4");

        GameObject[] array = { healt1,healt2,healt3,healt4};
        healthLabels = array;
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

    public void GameOver()
    {
        isActive = false;
        FinishMap();
        GameOverUI.SetActive(true);
    }

    public bool PlayerCanMove()
    {
        return isActive;
    }

    public void SetHealtLabels(int value)
    {
        healthLabels[0].SetActive(false);
        healthLabels[1].SetActive(false);
        healthLabels[2].SetActive(false);
        healthLabels[3].SetActive(false);

        if (value > 0)
        {
            healthLabels[0].SetActive(true);
        }
        if (value > 1)
        {
            healthLabels[1].SetActive(true);
        }
        if (value > 2)
        {
            healthLabels[2].SetActive(true);
        }
        if (value > 3)
        {
            healthLabels[3].SetActive(true);
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
