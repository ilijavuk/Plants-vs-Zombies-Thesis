using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShovel : MonoBehaviour
{
    public Texture2D shovelTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        //Office Object collector
        //shovelSprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Shovel.png");
    }
    /*
    public void TexturizeSprites()
    {

        //office_Stamp
        shovelTexture = new Texture2D((int)shovelSprite.rect.width, (int)shovelSprite.rect.height);
        var pixels = shovelSprite.texture.GetPixels((int)shovelSprite.textureRect.x,
                                                    (int)shovelSprite.textureRect.y,
                                                    (int)shovelSprite.textureRect.width,
                                                    (int)shovelSprite.textureRect.height);
        shovelTexture.SetPixels(pixels);
        shovelTexture.Apply();
    }
    */
    public void ChangeCursor()
    {
        Cursor.SetCursor(shovelTexture, hotSpot, cursorMode);
    }
}
