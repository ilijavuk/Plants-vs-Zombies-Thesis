using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DefeatAndVictory : MonoBehaviour
{
    public TextMeshProUGUI m_Text;
    public GameObject go;
    public AudioSource DefeatSound;
    public AudioSource ScreamSound;
    public Button ReloadLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Zombie")
        {
            m_Text.text = "GAME OVER!";
            m_Text.enabled = true;
            DefeatSound.Play();
            ScreamSound.Play();
            ReloadLevel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if(Counter.value >= Levels.spawns[Counter.currentLevel-1, 0])
        {
            if (PlayerPrefs.GetInt("savedLevel") == Counter.currentLevel) 
                PlayerPrefs.SetInt("savedLevel", Counter.currentLevel+1);
            go.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
