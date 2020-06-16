using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject successfinishUI;
    public GameObject failfinishUI;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(gameManager.GetCoins() < 10)
            {
                gameManager.FinishMap();
                failfinishUI.SetActive(true);
            }
            else
            {
                gameManager.FinishMap();
                successfinishUI.SetActive(true);
            }
        }
    }
}
