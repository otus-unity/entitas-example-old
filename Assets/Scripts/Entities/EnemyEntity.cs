using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : AbstractEntity
{
    public float health;

    protected override void Start()
    {
        base.Start();
        entity.isEnemy = true;
        entity.AddHealth(health);
    }
}
