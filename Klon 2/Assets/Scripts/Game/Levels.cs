using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Levels
{
    //list of levels
    static public int[,] spawns = new int [,] { 
        { 5 , 1 }, // level 1
        { 10, 1 }, // level 2
        { 12, 2 }, // level 3
        { 15, 3 }, // ...
        { 17, 3 }, 
        { 17, 3 }, 
        { 17, 3 }, 
        { 17, 3 }, 
        { 17, 3 }, 
        { 17, 3 },
    };

    static public int[,] levelTilemaps = new int[,]
    {
        { 0, 0, 1, 0, 0 }, // level 1
        { 0, 1, 1, 1, 0 }, // level 1
        { 1, 1, 1, 1, 1 }, // level 1
        { 1, 1, 1, 1, 1 }, // level 1
        { 1, 1, 1, 1, 1 }, // level 1
        { 1, 1, 1, 1, 1 }, // level 1
        { 1, 1, 1, 1, 1 }, // level 1
        { 1, 1, 1, 1, 1 }, // level 1
        { 1, 1, 1, 1, 1 }, // level 1
        { 1, 1, 1, 1, 1 }, // level 1
    };

    /*
     * static public readonly Dictionary<int, int>[] zombieSpawns = new Dictionary<int, int>[]
    {
        new Dictionary<int, int>(){ { 1, 1 }, { 1, 3 } }, // level 1
        new Dictionary<int, int>(){ { 1, 1 }, { 1, 3 } }, // level 2
    };
    */

    //static int[] numberOfZombies = new int[10] { 2, 5, 5, 3, 5, 5, 10, 12, 12, 12 };
}
