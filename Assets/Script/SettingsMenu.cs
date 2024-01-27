using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    [Header("Graphics")]
    [SerializeField] private TMPro.TMP_Dropdown DropdownGraphics;
    [SerializeField] private TMPro.TMP_Dropdown DropdownResolution;

    Resolution[] resolutions;

    [Header("Camera parameter")]
    [SerializeField] private Camera cam;
    [SerializeField] private Slider fovSlider;

    [SerializeField] private Toggle screenToggle;

    [Header("Instance")]
    [SerializeField] private static SettingsMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Bug Instance SettingsMenu");
            return;
        }
        instance = this;
    }

    public void Start()
    {
        audioMixer.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;

        audioMixer.GetFloat("Sound", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        fovSlider.value = cam.fieldOfView;


        //QualitySettings.GetActiveQualityLevelsForPlatform(out int qualityType);


        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        DropdownResolution.ClearOptions();
        
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        DropdownResolution.AddOptions(options);
        DropdownResolution.value = currentResolutionIndex;
        DropdownResolution.RefreshShownValue();

        Screen.fullScreen = true;
    }

    private void Update()
    {
        if(cam.fieldOfView == fovSlider.value)
        {
            cam.fieldOfView = fovSlider.value;
        }

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("Sound", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
