using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ShotCollisionSystem : IExecuteSystem, ICleanupSystem
{
    IGroup<GameEntity> shotEntities;
    IGroup<GameEntity> enemyEntities;
    List<Entity> deadEntities = new List<Entity>();

    public ShotCollisionSystem(Contexts contexts)
    {
        shotEntities = contexts.game.GetGroup(GameMatcher.Shot);
        enemyEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Health));
    }

    public void Execute()
    {
        deadEntities.Clear();
        foreach (var shot in shotEntities) {
            var shotPosition = shot.position.value;
            if (shotPosition.x < -75 || shotPosition.y > 65 || shotPosition.x > 50 || shotPosition.y < -35) {
                deadEntities.Add(shot);
                continue;
            }

            foreach (var enemy in enemyEntities) {
                var enemyPosition = enemy.position.value;
                if ((enemyPosition - shotPosition).sqrMagnitude < 0.5f) {
                    enemy.ReplaceHealth(enemy.health.value - 1.0f);
                    deadEntities.Add(shot);
                    break;
                }
            }
        }

        foreach (var e in deadEntities)
            e.Destroy();
    }

    public void Cleanup()
    {
        deadEntities.Clear();
    }
}
