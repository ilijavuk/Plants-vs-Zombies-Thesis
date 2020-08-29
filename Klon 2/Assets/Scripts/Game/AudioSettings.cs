using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Serializable]
    public struct AudioSources
    {
        public AudioSource audioSource;
        public string group;
    }

    public AudioSources[] audioSources;

    void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("music");
        float sfxVolume = PlayerPrefs.GetFloat("sfx");
        foreach(var audio in audioSources)
        {
            switch (audio.group)
            {
                case "music": audio.audioSource.volume = musicVolume;  break;
                case "sfx": audio.audioSource.volume = sfxVolume; break;
            }
            audio.audioSource.volume = musicVolume;
        }
        if (gameObject.name == "MusicSlider")
        {
            gameObject.GetComponent<Slider>().value = musicVolume;
        }
        else if (gameObject.name == "SFXSlider")
        {
            gameObject.GetComponent<Slider>().value = sfxVolume;
        }
    }

    public void SetMusicVolume(System.Single value)
    {
        if (gameObject.name == "MusicSlider")
        {
            PlayerPrefs.SetFloat("music", value);
        }
        else if (gameObject.name == "SFXSlider")
        {
            PlayerPrefs.SetFloat("sfx", value);
        }
    }

    public void StopPlaying()
    {
        Debug.Log("stopping");
        foreach(var audio in audioSources)
        {
            audio.audioSource.Stop();
        }
    }
}
