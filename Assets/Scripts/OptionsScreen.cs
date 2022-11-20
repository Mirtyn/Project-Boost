using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using static UnityEngine.UI.Slider;

public class OptionsScreen : ProjectBehaviour
{
    public Toggle fullscreenTog, vsyncTog;

    public List<ResItem> Resolutions = new List<ResItem>();
    private int selectedResolution;

    public TMP_Text ResolutionLabel;

    public AudioMixer TheMixer;

    public TMP_Text MasterLabel, MusicLabel, SFXLabel;
    public Slider MasterSlider, MusicSlider, SFXSlider;

    void Start()
    {
        MasterSlider.onValueChanged.AddListener(delegate { SetMasterVolume(); });
        MusicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        SFXSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });

        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        if(Resolutions.Count == 0)
        {
            Resolutions.Add(new ResItem { Horizontal = 1920, Vertical = 1080 });
            Resolutions.Add(new ResItem { Horizontal = 1366, Vertical = 768 });
            Resolutions.Add(new ResItem { Horizontal = 1280, Vertical = 800 });
            Resolutions.Add(new ResItem { Horizontal = 1280, Vertical = 720 });
            Resolutions.Add(new ResItem { Horizontal = 800, Vertical = 600 });
            Resolutions.Add(new ResItem { Horizontal = 720, Vertical = 480 });
        }

        bool foundRes = false;
        for (int i = 0; i < Resolutions.Count; i++)
        {
            if (Screen.width == Resolutions[i].Horizontal && Screen.height == Resolutions[i].Vertical)
            {
                foundRes = true;

                selectedResolution = i;

                UpdateResLabel();
            }
        }

        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.Horizontal = Screen.width;
            newRes.Vertical = Screen.height;

            Resolutions.Add(newRes);
            selectedResolution = Resolutions.Count - 1;

            UpdateResLabel();
        }

        float volume = 0f;
        TheMixer.GetFloat("MasterVolume", out volume);
        MasterSlider.value = volume;
        MasterLabel.text = Mathf.RoundToInt(MasterSlider.value + 80).ToString();

        TheMixer.GetFloat("MusicVolume", out volume);
        MusicSlider.value = volume;
        MusicLabel.text = Mathf.RoundToInt(MusicSlider.value + 80).ToString();

        TheMixer.GetFloat("SFXVolume", out volume);
        SFXSlider.value = volume;
        SFXLabel.text = Mathf.RoundToInt(SFXSlider.value + 80).ToString();
    }

    void Update()
    {
        
    }

    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > Resolutions.Count - 1)
        {
            selectedResolution = Resolutions.Count - 1;
        }
        
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        Debug.Log("log: " + ResolutionLabel.text);
        Debug.Log("Resolutions.Count: " + Resolutions.Count);
        Debug.Log("selectedResolution: " + selectedResolution);

        ResolutionLabel.text = Resolutions[selectedResolution].Horizontal + " x " + Resolutions[selectedResolution].Vertical;
    }

    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullscreenTog.isOn;

        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(Resolutions[selectedResolution].Horizontal, Resolutions[selectedResolution].Vertical, fullscreenTog.isOn);
    }

    public void SetMasterVolume()
    {
        MasterLabel.text = Mathf.RoundToInt(MasterSlider.value + 80).ToString();

        TheMixer.SetFloat("MasterVolume", MasterSlider.value);

        PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
    }

    public void SetMusicVolume()
    {
        MusicLabel.text = Mathf.RoundToInt(MusicSlider.value + 80).ToString();

        TheMixer.SetFloat("MusicVolume", MusicSlider.value);

        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }

    public void SetSFXVolume()
    {
        SFXLabel.text = Mathf.RoundToInt(SFXSlider.value + 80).ToString();

        TheMixer.SetFloat("SFXVolume", SFXSlider.value);

        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }
}

[System.Serializable]
public class ResItem
{
    public int Horizontal, Vertical;
}
