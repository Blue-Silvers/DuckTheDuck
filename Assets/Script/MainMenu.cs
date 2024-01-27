using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string LevelToLoad;
    [SerializeField] private string CreditsLoad;

    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject galleryWindow;
    [SerializeField] private GameObject chapSelecWindow;

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

    void Update()
    {
        //utiliser NIS
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsWindow.SetActive(false);
        }
    }
}
