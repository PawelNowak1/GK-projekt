using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseMap : MonoBehaviour
{
    public StepsManager stepsObject;
    public Button firstStep;
    public Button secondStep;
    public Button thirdStep;

    public void FirstMap()
    {
        SceneManager.LoadScene("SampleScene2");
    }

    public void SecondMap()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ThirdMap()
    {
        SceneManager.LoadScene("Level3");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("StartGame");
    }

    // Update is called once per frame
    void Update()
    {
        if(stepsObject.GetStep() == 0){
            firstStep.interactable = true;
            secondStep.interactable = false;
            thirdStep.interactable = false;
        }
        if (stepsObject.GetStep() == 1)
        {
            firstStep.interactable = false;
            secondStep.interactable = true;
            thirdStep.interactable = false;
        }
        if (stepsObject.GetStep() == 2)
        {
            firstStep.interactable = false;
            secondStep.interactable = false;
            thirdStep.interactable = true;
        }
    }
}
