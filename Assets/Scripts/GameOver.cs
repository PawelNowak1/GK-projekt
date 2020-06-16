using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string currentSceene;
    public GameObject gameOverUI;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameManager.FinishMap();
            gameOverUI.SetActive(true);
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("ChooseMap");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(currentSceene);
    }
}
