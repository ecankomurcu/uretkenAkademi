using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class OptionsManager : MonoBehaviour
{
    [SerializeField] private Toggle muteToggle;
    [SerializeField] private Toggle windowedToggle;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private TextMeshProUGUI VolumeText;
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Mute"))
        {
            PlayerPrefs.SetInt("Mute",0);
        }
        else
        {
            loadToggle();
        }

       if(PlayerPrefs.HasKey("Windowed"))
        {
            PlayerPrefs.SetInt("Windowed",0);
        }
       else
        {
            LoadWindowedToggle();
        }
        LoadVolume();
    }
    private void loadToggle()
    {
        muteToggle.isOn = PlayerPrefs.GetInt("Mute") == 1;
    }

    public void MuteToggle()
    {
        PlayerPrefs.SetInt("Mute", muteToggle.isOn ? 1 : 0);

        if(muteToggle.isOn)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    public void WindowedToggle()
    {
        PlayerPrefs.SetInt("Windowed", windowedToggle.isOn ? 1 : 0);

        if(!windowedToggle.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;

        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void LoadWindowedToggle()
    {
        windowedToggle.isOn = PlayerPrefs.GetInt("Windowed") == 1;
    }

    private void LoadVolume()
    {
        float volumeVolue = PlayerPrefs.GetFloat("Volume");
        VolumeSlider.value = volumeVolue;
        AudioListener.volume = volumeVolue;
    }
    public void VolumeControl(float volume)
    {
        VolumeText.text = "volume " + volume.ToString("0");
        float volumeVolue = VolumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeVolue);

    }
    private void Update()
    {
        LoadVolume();
    }
}
