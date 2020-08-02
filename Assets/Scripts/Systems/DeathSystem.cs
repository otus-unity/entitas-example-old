using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;

public class DeathSystem : JobComponentSystem
{
    EndSimulationEntityCommandBufferSystem commandBufferSystem;

    protected override void OnCreate()
    {
        base.OnCreate();
        commandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var commandBuffer = commandBufferSystem.CreateCommandBuffer().ToConcurrent();
        var job = Entities.ForEach((Entity entity, int entityInQueryIndex, ref HealthComponent health) => {
                if (health.value <= 0)
                    commandBuffer.DestroyEntity(entityInQueryIndex, entity);
            }).Schedule(inputDeps);

        commandBufferSystem.AddJobHandleForProducer(job);
        return job;
    }
}
