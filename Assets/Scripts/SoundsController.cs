using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [Header("Sound Vars")]
    public float soundEffectsVolume = 1;
    public float musicVolume = 1;

    void Awake()
    {
        soundEffectsVolume = PlayerPrefs.GetFloat("soundEffectsVolume");
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
    }

    public void UpdateVolumes(float newSoundEffectsVolume, float newMusicVolume)
    {
        soundEffectsVolume = newSoundEffectsVolume;
        musicVolume = newMusicVolume;

        SaveVolumes();
    }

    void SaveVolumes()
    {
        PlayerPrefs.SetFloat("soundEffectsVolume", soundEffectsVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);

        PlayerPrefs.Save();
    }
}
