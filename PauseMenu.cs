using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider speedSlider;
    public Toggle fullScreenToggle;
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

        fullScreenToggle.isOn = Screen.fullScreen;
    }
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution =resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ToggleFullScreen()
    {
        // Toggle full screen mode
        Screen.fullScreen = !Screen.fullScreen;

        // Update toggle state based on the new full screen setting
        fullScreenToggle.isOn = Screen.fullScreen;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = speedSlider.value / 4;
        GameIsPaused = false;
    }
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        speedSlider.value = Time.timeScale * 4;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Levels()
    {
        Resume();
        SceneManager.LoadScene("Level Select");
    }
    //everything after this is for the options stuff
    public void Options()
    {
        pauseMenuUI.SetActive(false);
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
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }
}
