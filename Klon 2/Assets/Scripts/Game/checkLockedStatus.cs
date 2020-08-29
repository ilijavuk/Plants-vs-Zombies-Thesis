using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class checkLockedStatus : MonoBehaviour
{
    public Tilemap[] rows;
    public GameObject FirstAndLast;
    public GameObject SecondAndFourth;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < rows.Length; i++)
        {
            if (Levels.levelTilemaps[Counter.currentLevel-1, i] != 0)
            {
                rows[i].tag = "Ground";
                TilemapRenderer sprite = rows[i].GetComponent<TilemapRenderer>();
                sprite.sortingLayerName = "Ground";
            }
        }
        if (Levels.levelTilemaps[Counter.currentLevel - 1, 0] != 0)
        {
            FirstAndLast.SetActive(false);
            SecondAndFourth.SetActive(false);
        }
        else if (Levels.levelTilemaps[Counter.currentLevel - 1, 1] != 0)
        {
            SecondAndFourth.SetActive(false);
        }
    }
}
