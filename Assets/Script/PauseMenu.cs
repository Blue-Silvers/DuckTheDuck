using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsWindow;
    public bool WindowOpen = false;

    void Update()
    {
        //utiliser NIS
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (WindowOpen == true)
            {
                settingsWindow.SetActive(false);
                WindowOpen = false;
            }
            else
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Paused();
                }
            }
        }
    }

    void Paused()
    {
        //PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        //PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
        WindowOpen = true;
    }

    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
        WindowOpen = false;
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
