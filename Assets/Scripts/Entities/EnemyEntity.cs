using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : AbstractEntity
{
    public float health;

    protected override void Start()
    {
        base.Start();
        entity.AddEnemy(0.0f);
        entity.AddHealth(health);
    }
}
