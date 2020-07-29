using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Levels
{
    //list of levels
    // 0 - Forbidden, 1 - Normal ground
    static int[,] levelGround = new int[10, 5] { 
        { 0, 0, 1, 0, 0 }, 
        { 0, 1, 1, 1, 0 }, 
        { 0, 1, 1, 1, 0 },
        { 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1 },
    };

    //static int[] numberOfZombies = new int[10] { 2, 5, 5, 3, 5, 5, 10, 12, 12, 12 };
}
