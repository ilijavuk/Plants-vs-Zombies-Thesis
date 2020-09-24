using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Levels
{
    //list of levels
    static public int[,] spawns = new int [,] {
        { 5 , 1 }, // level 1
        { 8 , 2 }, // level 2
        { 13, 3 }, // level 3
        { 21, 3 }, // ...
        { 25, 3 },
        { 27, 4 },
        { 35, 4 },
        { 45, 5 },
        { 55, 5 },
        { 65, 5 },
    };
    static public int[,] levelTilemaps = new int[,]
    {
        { 0, 0, 1, 0, 0 }, // level 1
        { 0, 1, 1, 1, 0 }, // level 2
        { 1, 1, 1, 1, 1 }, // level 3
        { 1, 1, 1, 1, 1 }, // level 4
        { 1, 1, 1, 1, 1 }, // level 5
        { 1, 1, 1, 1, 1 }, // level 6
        { 1, 1, 1, 1, 1 }, // level 7
        { 1, 1, 1, 1, 1 }, // level 8
        { 1, 1, 1, 1, 1 }, // level 9
        { 1, 1, 1, 1, 1 }, // level 10
    };

}
