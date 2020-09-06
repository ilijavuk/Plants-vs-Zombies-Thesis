﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    public Texture2D shovelTexture;
    public static bool toggledOn = false;

    public void ChangeCursor()
    {
        if (!toggledOn && CarryingPlant.IsCarrying == false)
        {
            Cursor.SetCursor(shovelTexture, Vector2.zero, CursorMode.Auto);
        }
        else{
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        toggledOn = !toggledOn;
    }
}
