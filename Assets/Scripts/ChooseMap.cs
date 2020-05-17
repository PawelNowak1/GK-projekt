using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMap : MonoBehaviour
{
    public void FirstMap()
    {
        SceneManager.LoadScene("SampleScene2");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("StartGame");
    }
}
