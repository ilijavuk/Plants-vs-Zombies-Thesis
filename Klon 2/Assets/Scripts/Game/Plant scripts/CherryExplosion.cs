using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryExplosion : Explosion
{
    public override void SetStart(bool value)
    {
        Invoke("StartAnimation", countdown);
    }
}

