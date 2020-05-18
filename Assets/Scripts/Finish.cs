using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject finishUI;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            gameManager.FinishMap();
            finishUI.SetActive(true);
        }
    }
}
