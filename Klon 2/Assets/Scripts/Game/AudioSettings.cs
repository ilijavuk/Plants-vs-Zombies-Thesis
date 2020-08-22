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
        if (gameObject.name == "Slider")
        {
            gameObject.GetComponent<Slider>().value = musicVolume;
        }
    }

    public void SetMusicVolume(System.Single value)
    {
        PlayerPrefs.SetFloat("music", value);
    }
}
