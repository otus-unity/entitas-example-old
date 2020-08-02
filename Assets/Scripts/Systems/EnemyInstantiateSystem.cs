using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class EnemyInstantiateSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;

    public EnemyInstantiateSystem(Contexts contexts)
        : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Enemy);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEnemy && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities) {
            var obj = GameObject.Instantiate(contexts.game.globals.enemyPrefab);
            e.AddView(obj);
        }
    }
}
*/
