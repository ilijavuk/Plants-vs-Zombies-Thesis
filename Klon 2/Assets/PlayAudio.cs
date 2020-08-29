using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource Audio;
    public AudioSource Music;

    private void OnMouseDown()
    {
        Audio.Play();
    }

    public void StartPlayingAudio()
    {
        Music.volume = 0;
        Audio.Play();
    }
}
