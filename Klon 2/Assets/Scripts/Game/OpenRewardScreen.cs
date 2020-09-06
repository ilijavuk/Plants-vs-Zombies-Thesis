using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenRewardScreen: MonoBehaviour
{
    public AudioSource Audio;
    public AudioSource Music;
    public GameObject GO;
    public Sprite[] RewardSprites;
    public Sprite[] SeedPacketSprites;

    private void Start()
    {
        GO.GetComponent<SpriteRenderer>().sprite = RewardSprites[Counter.currentLevel - 1];
        GetComponent<SpriteRenderer>().sprite = SeedPacketSprites[Counter.currentLevel - 1];
    }

    void OnMouseDown()
    {
        Audio.Play();
        GO.SetActive(true);
        if(Counter.currentLevel == 10)
        {
            GO.GetComponentInChildren<Button>().gameObject.SetActive(false);
        }
    }

    public void StartPlayingAudio()
    {
        Music.Stop();
        Audio.Play();
    }
}
