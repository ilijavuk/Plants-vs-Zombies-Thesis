using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DefeatAndVictory : MonoBehaviour
{
    public GameObject go;
    public AudioSource DefeatSound;
    public AudioSource ScreamSound;
    public Button ReloadLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Zombie")
        {
            DefeatSound.Play();
            ScreamSound.Play();
            ReloadLevel.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameObject.Find("Spawn suns").GetComponent<SunSpawn>().StopSpawning();
        }
    }

    private void Update()
    {
        if(Counter.value >= Levels.spawns[Counter.currentLevel-1, 0])
        {
            if (!PlayerPrefs.HasKey("savedLevel") || PlayerPrefs.GetInt("savedLevel") == Counter.currentLevel) 
                PlayerPrefs.SetInt("savedLevel", Counter.currentLevel+1);
            go.SetActive(true);
            GameObject.Find("Spawn suns").GetComponent<SunSpawn>().StopSpawning();
        }
    }
}
