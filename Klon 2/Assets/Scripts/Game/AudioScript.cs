using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private AudioSource[] audioSources;

    private void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
    }

    public void PlaySound(int index)
    {
        audioSources[index].Play();
    }
}
