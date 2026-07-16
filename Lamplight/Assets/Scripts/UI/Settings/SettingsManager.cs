using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioController;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Toggle fullScreen;
    [SerializeField] private TMP_Text resolutionText;
    [SerializeField] private MainMenuManager manager;
    [SerializeField] private List<Vector2> resolutions;
    private int selectedResolution;
    private void Start()
    {
        audioController.SetFloat("MasterVolume", Mathf.Log10(manager.fileData.masterVolume) * 20);
        audioController.SetFloat("MusicVolume", Mathf.Log10(manager.fileData.musicVolume) * 20);
        audioController.SetFloat("soundEffectsVolume", Mathf.Log10(manager.fileData.soundEffectVolume) * 20);
        masterVolumeSlider.value = manager.fileData.masterVolume;
        musicVolumeSlider.value = manager.fileData.musicVolume;
        fullScreen.isOn = Screen.fullScreen;
        selectedResolution = manager.fileData.selectedResolution;
        updateResolutionText();
    }
    public void setMasterVolume(float value)
    {
        manager.fileData.masterVolume = value;
        audioController.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }
    public void setMusicVolume(float value)
    {
        manager.fileData.musicVolume = value;
        audioController.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }
    public void setEffectsVolume(float value)
    {
        manager.fileData.soundEffectVolume = value;
        audioController.SetFloat("soundEffectsVolume", Mathf.Log10(value) * 20);
    }
    public void updateResolutionText()
    {
        resolutionText.text = resolutions[selectedResolution].x + "X" + resolutions[selectedResolution].y;
    }
    public void resolutionChange(int change)
    {
        selectedResolution += change;
        if (selectedResolution >= resolutions.Count)
        {
            selectedResolution = resolutions.Count - 1;
        } 
        else if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        updateResolutionText();
    }
    public void applyGraphicalChanges()
    {
        Screen.SetResolution((int) resolutions[selectedResolution].x, (int) resolutions[selectedResolution].y, fullScreen.isOn);
        manager.fileData.selectedResolution = selectedResolution;
    }
}
