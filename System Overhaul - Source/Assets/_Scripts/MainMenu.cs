using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject OptionsMenu;
    public GameObject panel;
    public void StartGame()
    {
        //PlayerPrefs.Save();
     
 
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("SampleScene 1");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void ReturntoMainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");

    }

    public void Resume()
    {
        GameIsPaused = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
       

    }

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                panel.SetActive(false);
                GameIsPaused = !GameIsPaused;
                Resume();
            }
            else
            {
                panel.SetActive(true);
                Pause();
            }
        }
    }


}
