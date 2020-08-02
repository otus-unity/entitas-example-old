using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class EnemyMovementSystem : IExecuteSystem, ICleanupSystem
{
    Contexts contexts;
    IGroup<GameEntity> entities;
    List<(Vector2 position, float health)> clones = new List<(Vector2, float)>();

    public EnemyMovementSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
        int enemyCount = 0;

        clones.Clear();
        foreach (var e in entities) {
            ++enemyCount;

            e.enemy.timeUntilNextTurn -= Time.deltaTime;
            if (e.enemy.timeUntilNextTurn <= 0.0f) {
                e.ReplaceRotation(Random.Range(0.0f, 360.0f));
                e.ReplaceEnemy(Random.Range(0.5f, 1.5f));

                if (Random.Range(0.0f, 30.0f) < 1.0f)
                    clones.Add((e.position.value, e.health.value));
            }

            var angle = e.rotation.angle * Mathf.Deg2Rad;
            var dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            e.ReplacePosition(e.position.value + dir * 5.0f * Time.deltaTime);
        }

        foreach (var clone in clones) {
            var cloneEntity = contexts.game.CreateEntity();
            cloneEntity.AddPosition(clone.position);
            cloneEntity.AddRotation(Random.Range(0.0f, 360.0f));
            cloneEntity.ReplaceEnemy(Random.Range(0.5f, 1.5f));
            cloneEntity.AddHealth(clone.health);
            ++enemyCount;
        }

        contexts.game.globals.enemyCountText.text = $"Enemies: {enemyCount}";
    }

    public void Cleanup()
    {
        clones.Clear();
    }
}
