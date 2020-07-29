using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DefeatAndVictory : MonoBehaviour
{
    public TextMeshProUGUI m_Text;
    public GameObject go;
    public int level;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Zombie")
        {
            m_Text.text = "GAME OVER!";
            m_Text.enabled = true;
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if(Counter.value >= Counter.brojZombija)
        {
            PlayerPrefs.SetInt("savedLevel", level+1);
            go.SetActive(true);
        }
    }
}
