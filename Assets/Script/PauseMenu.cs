using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool gameIsPaused = false;

    [Header("Windows")]
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject settingsWindow;
    private bool WindowOpen = false;

    [Header("Input Manager (don't touch)")]
    [SerializeField] private InputActionReference escapeM;

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

    private void OnEnable()
    {
        escapeM.action.started += EscapeM;
    }
    private void EscapeM(InputAction.CallbackContext obj)
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

