using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OptionsMenu : MonoBehaviour
{
    public GameObject Panel;
    private bool PanelToggledOn = false;

    private void Start()
    {
        Counter.value = 0;
    }

    public void SwitchToMainMenu()
    {
        Time.timeScale = 1;
        Counter.value = 0;
        Collecting.money = 50;
        SceneManager.LoadScene(0);
    }

    public void ProceedToNextLevel()
    {
        Counter.currentLevel++;
        Time.timeScale = 1;
        Counter.value = 0;
        Collecting.money = 50;
        SceneManager.LoadScene("Level_1");
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {//When a key is pressed down it see if it was the escape key if it was it will execute the code
            if (!PanelToggledOn)
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void PauseGame()
    {
        PanelToggledOn = true;
        Panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PanelToggledOn = false;
        Panel.SetActive(false);
        Time.timeScale = 1;
    }
}
