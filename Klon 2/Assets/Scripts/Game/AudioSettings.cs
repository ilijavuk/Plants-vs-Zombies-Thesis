using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        float musicVolume = PlayerPrefs.GetFloat("music");
        if (audioSource)
            audioSource.volume = musicVolume;
        else if (gameObject.name == "Slider")
        {
            gameObject.GetComponent<Slider>().value = musicVolume;
        }
    }

    public void SetMusicVolume(System.Single value)
    {
        PlayerPrefs.SetFloat("music", value);
    }
}
