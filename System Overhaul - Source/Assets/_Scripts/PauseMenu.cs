using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public GameObject OptionsMenu;
    public static bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {

     
        pauseMenuUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    
        
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    GameIsPaused = !GameIsPaused;
                    Resume();
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    Pause();
                }
            }
        
       
    }
    public void Resume()
    {

        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
    
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
        Debug.Log("Loading Menu");
  

    }


    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
