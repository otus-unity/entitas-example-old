using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ShotInstantiateSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;

    public ShotInstantiateSystem(Contexts contexts)
        : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Shot);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isShot && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities) {
            var obj = GameObject.Instantiate(contexts.game.globals.shotPrefab);
            e.AddView(obj);
        }
    }
}
