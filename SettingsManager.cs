using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullScreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Slider musicVolumeSlider;
    public Slider gammaSlider;
    public Button applyButton;

    public AudioSource musicSource;
    public Resolution[] resolutions;
    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        gammaSlider.onValueChanged.AddListener(delegate { OnGammaChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void OnFullScreenToggle()
    {
      gameSettings.fullscreen = Screen.fullScreen = fullScreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
      Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
      gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    public void OnTextureQualityChange()
    {
      QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;  
    }

    public void OnMusicVolumeChange()
    {
      musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }

    public void OnGammaChange()
    {
      gameSettings.gameGamma = Screen.brightness = gammaSlider.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
      string jsonData = JsonUtility.ToJson(gameSettings, true);
      File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
      gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

      musicVolumeSlider.value = gameSettings.musicVolume;
      gammaSlider.value = gameSettings.gameGamma;
      resolutionDropdown.value = gameSettings.resolutionIndex;
      textureQualityDropdown.value = gameSettings.textureQuality;
      fullScreenToggle.isOn = gameSettings.fullscreen;
      Screen.fullScreen = gameSettings.fullscreen;

      resolutionDropdown.RefreshShownValue();    
    }
}
