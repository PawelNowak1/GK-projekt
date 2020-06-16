using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public GameObject coin;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (gameManager.isGameActive())
            {
                gameManager.AddCoin();
                coin.SetActive(false);
            }
        }
    }
}
