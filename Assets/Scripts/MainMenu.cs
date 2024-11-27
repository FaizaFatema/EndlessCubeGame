using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    public GameObject mainMenu;
    public GameObject player;
 
    public  bool IsmainMenu=true;

    public Transform startposition;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
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
        player.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.transform.position = startposition.position;
        player.SetActive(true);
        player.GetComponent<Player>().enabled = true;
        Score.Instance.score = 0;
        MainMenu.Instance.mainMenu.SetActive(false);
        Time.timeScale = 1f;
       
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
