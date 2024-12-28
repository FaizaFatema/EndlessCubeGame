using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public MainMenu main;
    public GameController controller;
    public SoundManager soundManager;
   
    public static bool GameISPaused=false;
    public GameObject pauseMenuUI;

    public Button pauseButton;

    private void Update()
    {
        if (controller.isGameOver == false&&main.IsmainMenu==false)
        {

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (GameISPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }
    public void Resume()    
    {
       soundManager.ResumeMusic();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameISPaused = false;
        pauseButton.enabled = true;
    }
    public void Pause()
    {
       soundManager.PauseMusic();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameISPaused = true;
        pauseButton.enabled = false;
    }
    public void LoadMenu()
    {
        soundManager.StopMusic();
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(false);
       main.mainMenu.SetActive(true);
        pauseButton.enabled = true;
    }
    public void QuitGame()
    {
      Application.Quit();
    }
}
