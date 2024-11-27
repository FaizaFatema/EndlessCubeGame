using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    
    public bool isGameOver = false;
   
    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);

    }

    public void Restart()
    {
        isGameOver=false;
        gameOverPanel.SetActive(false);
        Time.timeScale = 0f;
       MainMenu.Instance.mainMenu.SetActive(true);
    }
    public void Quit()
    {
        Debug.Log("GAME IS QUIT");
        Application.Quit();
    }
}
