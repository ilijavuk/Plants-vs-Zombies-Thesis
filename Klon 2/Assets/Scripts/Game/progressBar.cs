using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class progressBar : MonoBehaviour
{
    public TMPro.TextMeshProUGUI m_text_current;
    public TMPro.TextMeshProUGUI m_text_number;
    private float var;
    
    private void Start()
    {
        m_text_number.text = "/"+Levels.spawns[Counter.currentLevel-1, 0].ToString();
        Debug.Log(Levels.spawns[Counter.currentLevel - 1, 0]);
    }
    void Update()
    {
        m_text_current.text = Counter.value.ToString();
    }
}
