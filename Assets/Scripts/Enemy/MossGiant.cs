using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    public override void Init()
    {
        base.Init();
        target = pointB.position;
        speed = 0.75f;
    }
}
