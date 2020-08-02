using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class ShotMovementSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;

    public ShotMovementSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.Shot);
    }

    public void Execute()
    {
        foreach (var e in entities) {
            var angle = e.rotation.angle * Mathf.Deg2Rad;
            var dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            e.ReplacePosition(e.position.value + dir * 60.0f * Time.deltaTime);
        }
    }
}
*/
