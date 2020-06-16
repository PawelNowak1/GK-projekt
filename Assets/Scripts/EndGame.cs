using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public StepsManager stepsManager;

    public void EndGameFun()
    {
        stepsManager.SetStep(0);
        SceneManager.LoadScene("StartGame");
    }
}
