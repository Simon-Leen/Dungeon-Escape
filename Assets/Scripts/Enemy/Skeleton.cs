using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        target = pointB.position;
        speed = 0.5f;
    }

    public void Damage()
    {

    }
}
