using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource Audio;
    public AudioSource Music;
    public GameObject GO;

    void OnMouseDown()
    {
        Audio.Play();
        GO.SetActive(true);
    }

    public void StartPlayingAudio()
    {
        Music.Stop();
        Audio.Play();
    }
}
