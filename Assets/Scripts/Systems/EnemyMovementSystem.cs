using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

public class EnemyMovementSystem : IExecuteSystem, ICleanupSystem
{
    struct EnemyData
    {
        public Vector2 position;
        public float angle;
    }

    [BurstCompile]
    struct UpdateJob : IJobParallelFor
    {
        public float deltaTime;
        public NativeArray<EnemyData> enemyData;

        public void Execute(int index)
        {
            var data = enemyData[index];

            var angle = data.angle * Mathf.Deg2Rad;
            var dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            data.position += dir * 5.0f * deltaTime;

            enemyData[index] = data;
        }
    }

    Contexts contexts;
    IGroup<GameEntity> entities;
    List<(Vector2 position, float health)> clones = new List<(Vector2, float)>();
    UpdateJob updateJob;

    public EnemyMovementSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Enemy);
        updateJob = new UpdateJob();
    }

    public void Execute()
    {
        int enemyCount = entities.count;
        var enemyArray = new NativeArray<EnemyData>(enemyCount, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);

        clones.Clear();
        int i = 0;
        foreach (var e in entities) {
            e.enemy.timeUntilNextTurn -= Time.deltaTime;
            if (e.enemy.timeUntilNextTurn <= 0.0f) {
                e.ReplaceRotation(Random.Range(0.0f, 360.0f));
                e.ReplaceEnemy(Random.Range(0.5f, 1.5f));

                if (Random.Range(0.0f, 30.0f) < 1.0f)
                    clones.Add((e.position.value, e.health.value));
            }

            enemyArray[i++] = new EnemyData{ position = e.position.value, angle = e.rotation.angle };
        }

        updateJob.deltaTime = Time.deltaTime;
        updateJob.enemyData = enemyArray;

        JobHandle jobHandle = updateJob.Schedule(enemyCount, 1);
        jobHandle.Complete();

        i = 0;
        foreach (var e in entities)
            e.ReplacePosition(enemyArray[i++].position);

        enemyArray.Dispose();

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
