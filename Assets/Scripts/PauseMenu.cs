using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public MainMenu main;
    public GameController controller;

    public static bool GameISPaused=false;
    public GameObject pauseMenuUI;
  
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameISPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameISPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(false);
       main.mainMenu.SetActive(true);
    }
    public void QuitGame()
    {
      Application.Quit();
    }
}
