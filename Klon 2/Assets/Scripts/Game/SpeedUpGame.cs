using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpGame : MonoBehaviour
{
    bool IsSpedUp = false;
    
    public void ToggleSpeed()
    {
        IsSpedUp = !IsSpedUp;
        Color col = GetComponent<Image>().color;
        if (IsSpedUp)
        {
            col.r = 0.5f;
            col.g = 0.5f;
            col.b = 0.5f;
            Time.timeScale = 2.4f;
        }
        else
        { 
            col.r = 1;
            col.g = 1;
            col.b = 1;
            Time.timeScale = 1.2f;
        }
        GetComponent<Image>().color = col;
    }

    void Start()
    {
        Time.timeScale = 1.2f;
    }
}
