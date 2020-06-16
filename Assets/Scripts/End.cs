using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public int endStep;
    public string currentScene;
    public StepsManager stepsManager;

    public void EndMap()
    {
        stepsManager.SetStep(endStep);
        SceneManager.LoadScene("ChooseMap");
    }

    public void RestartMap()
    {
        SceneManager.LoadScene(currentScene);
    }
}
