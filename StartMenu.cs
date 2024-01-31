using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject optionsMenuUI;
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider speedSlider;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Levels()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level Select");
    }
    public void Quit()
    {
        Application.Quit();
    }
    //everything after this is for the options stuff
    public void Options()
    {
        startMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        masterVolumeSlider.value = GetMasterLevel();
        sfxVolumeSlider.value = GetSFXLevel();
        musicVolumeSlider.value = GetMusicLevel();
    }
    public float GetMasterLevel()
    {
        float value;
        bool result = audioMixer.GetFloat("masterVolume", out value);
        return value;
    }
    public float GetSFXLevel()
    {
        float value;
        bool result = audioMixer.GetFloat("SFXVolume", out value);
        return value;
    }
    public float GetMusicLevel()
    {
        float value;
        bool result = audioMixer.GetFloat("musicVolume", out value);
        return value;
    }
    public void FullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetMasterVolume(float masterVolume)
    {
        audioMixer.SetFloat("masterVolume", masterVolume);
    }
    public void SetSFXVolume(float SFXVolume)
    {
        audioMixer.SetFloat("SFXVolume", SFXVolume);
    }
    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("musicVolume", musicVolume);
    }
    public void Back()
    {
        startMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }
}

