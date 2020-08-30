using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CheckLockedStatus : MonoBehaviour
{
    [Serializable]
    public struct Buttons
    {
        public Button button;
        public int unLockedAt;
    }

    public Tilemap[] Rows;
    public GameObject FirstAndLast;
    public GameObject SecondAndFourth;
    public Buttons[] ButtonArray;

    void Start()
    {
        for (int i = 0; i < Rows.Length; i++)
        {
            if (Levels.levelTilemaps[Counter.currentLevel - 1, i] != 0)
            {
                Rows[i].tag = "Ground";
            }
        }
        if (Levels.levelTilemaps[Counter.currentLevel - 1, 1] == 0)
        {
            FirstAndLast.SetActive(true);
        }
        else if (Levels.levelTilemaps[Counter.currentLevel - 1, 0] == 0)
        {
            SecondAndFourth.SetActive(true);
        }

        for(int i = 0; i < ButtonArray.Length; i++)
        {
            if (ButtonArray[i].unLockedAt < Counter.currentLevel)
                ButtonArray[i].button.gameObject.SetActive(true);
        }
    }
}
