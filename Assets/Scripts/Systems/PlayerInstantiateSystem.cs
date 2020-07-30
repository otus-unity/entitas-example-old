using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerInstantiateSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;

    public PlayerInstantiateSystem(Contexts contexts)
        : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Player);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPlayer && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities) {
            var obj = GameObject.Instantiate(contexts.game.globals.playerPrefab);
            e.AddView(obj);
        }
    }
}
