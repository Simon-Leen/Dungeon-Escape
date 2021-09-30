using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public override void Init()
    {
        base.Init();
        target = pointB.position;
        speed = 0.5f;
    }
}
