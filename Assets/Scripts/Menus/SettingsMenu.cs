using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour{
    public AudioMixer settingsMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public GameObject settingMenuUI;
    public static bool settingsOpen = false;

    void Start()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameSettings"));
        resolutions = Screen.resolutions;
        SetQuality(3);

        resolutionDropdown.ClearOptions();
        List<string> resOptions = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i<resolutions.Length; i++)
        {
            string resOption = resolutions[i].width + " x " + resolutions[i].height;
            resOptions.Add(resOption);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resolutionDropdown.AddOptions(resOptions);
        resolutionDropdown.value =currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }

    void Update()
    {
        IsVisible(settingsOpen);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float Volume)
    {
        Debug.Log("volume set to: " + Volume);
        settingsMixer.SetFloat("volume", Volume);
    }

    public void SetQuality(int qualityScore)
    {
        Debug.Log("quality set to: " + qualityScore);
        QualitySettings.SetQualityLevel(qualityScore);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void IsVisible(bool visible)
    {
        settingMenuUI.SetActive(visible);
    }

}
