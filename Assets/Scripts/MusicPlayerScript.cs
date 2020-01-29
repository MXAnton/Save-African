using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip musicClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        SetMusicVolume(PlayerPrefs.GetFloat("musicVolume"));
        audioSource.loop = true;
        audioSource.clip = musicClip;
        audioSource.Play();
    }

    public void SetMusicVolume(float newVolume)
    {
        audioSource.volume = newVolume;

        //if (newVolume <= 0)
        //{
        //    audioSource.Pause();
        //}
        //else if (audioSource.isPlaying == false)
        //{
        //    audioSource.UnPause();
        //}
    }
}
