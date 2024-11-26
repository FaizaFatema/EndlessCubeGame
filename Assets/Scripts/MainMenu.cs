using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject mainMenu;
    public  bool IsmainMenu=true;

    public void Start()
    {
        Time.timeScale = 0f;
        IsmainMenu = true;
        mainMenu.SetActive(true);
       
    }
    public void PlayGame()
    {
        IsmainMenu= false;
        mainMenu.SetActive(false);
        Time.timeScale = 1f;
       
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
