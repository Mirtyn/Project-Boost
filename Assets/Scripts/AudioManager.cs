using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : ProjectBehaviour
{
    public AudioMixer theMixer;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            theMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        }
        
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            theMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            theMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
        }
    }
}
