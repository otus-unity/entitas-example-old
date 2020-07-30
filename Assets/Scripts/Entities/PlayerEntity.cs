using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : AbstractEntity
{
    public float health;

    protected override void Start()
    {
        base.Start();
        entity.isPlayer = true;
        entity.AddHealth(health);
    }
}
