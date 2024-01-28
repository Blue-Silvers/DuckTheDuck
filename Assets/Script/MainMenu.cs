using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Level selection for button")]
    [SerializeField] private string LevelToLoad;
    [SerializeField] private string CreditsLoad;

    [Header("Windows")]
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject galleryWindow;
    [SerializeField] private GameObject chapSelecWindow;


    [Header("Input Manager (don't touch)")]
    [SerializeField] private InputActionReference escapeM;
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void NewGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void SettingsButton()
    {
         settingsWindow.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
    }

    public void Credit()
    {
        SceneManager.LoadScene(CreditsLoad);
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsWindow.SetActive(false);
        }
    }
}
