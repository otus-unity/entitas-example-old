using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ShotCollisionSystem : IExecuteSystem
{
    IGroup<GameEntity> shotEntities;
    IGroup<GameEntity> enemyEntities;

    public ShotCollisionSystem(Contexts contexts)
    {
        shotEntities = contexts.game.GetGroup(GameMatcher.Shot);
        enemyEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Health));
    }

    public void Execute()
    {
        foreach (var shot in shotEntities) {
            var shotPosition = shot.position.value;
            foreach (var enemy in enemyEntities) {
                var enemyPosition = enemy.position.value;
                if ((enemyPosition - shotPosition).sqrMagnitude < 0.5f)
                    enemy.ReplaceHealth(enemy.health.value - 1.0f);
            }
        }
    }
}
