using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private int savedLevel;

    void Start()
    {
        if(PlayerPrefs.HasKey("savedLevel"))
        {
            savedLevel = PlayerPrefs.GetInt("savedLevel");
            EnableButtons(savedLevel);
        }
        else{
            EnableButtons(1);        }
    }
    
    void EnableButtons(int lastLevel)
    {
        Button[] list = Object.FindObjectsOfType<Button>();

        var transparentColorBlock = list[1].colors;
        transparentColorBlock.disabledColor = new Color(1, 1, 1, 0);

        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].name == "BackButton")
                continue;
            int level = int.Parse(list[i].name.Split('_')[1]);
            if(lastLevel < level)
            {
                Behaviour bhvr = (Behaviour)list[i];
                bhvr.enabled = false;
                list[i].colors = transparentColorBlock;
                TextMeshProUGUI text = list[i].GetComponentInChildren<TextMeshProUGUI>();
                text.text = "-";
            }
        }
    }

    public void StartLevel(int level)
    {
        Counter.currentLevel = level;
        SceneManager.LoadSceneAsync($"Level_1");
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
