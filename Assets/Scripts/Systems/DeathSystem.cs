using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class DeathSystem : IExecuteSystem, ICleanupSystem
{
    IGroup<GameEntity> entities;
    List<Entity> deadEntities = new List<Entity>();

    public DeathSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.Health);
    }

    public void Execute()
    {
        deadEntities.Clear();
        foreach (var e in entities) {
            if (e.health.value <= 0)
                deadEntities.Add(e);
        }

        foreach (var e in deadEntities)
            e.Destroy();
    }

    public void Cleanup()
    {
        deadEntities.Clear();
    }
}
