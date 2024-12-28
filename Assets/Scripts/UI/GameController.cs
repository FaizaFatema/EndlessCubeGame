using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public SoundManager soundManager;
   
    public bool isGameOver = false;

    public Button pauseButton;

    public void GameOver()
    {
        soundManager.StopMusic();
        isGameOver = true;
        gameOverPanel.SetActive(true);
    
    }

    public void Restart()
    {
        
        soundManager.ResumeMusic();
        isGameOver=false;
        gameOverPanel.SetActive(false);
        Time.timeScale = 0f;
        MainMenu.Instance.mainMenu.SetActive(true);
        pauseButton.enabled = true;

    }
    public void Quit()
    {
        Debug.Log("GAME IS QUIT");
        Application.Quit();
    }
}
