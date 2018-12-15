using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour{
    public AudioMixer settingsMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

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

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float Volume)
    {
        settingsMixer.SetFloat("volume", Volume);
    }

    public void SetQuality(int qualityScore)
    {
        QualitySettings.SetQualityLevel(qualityScore);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
