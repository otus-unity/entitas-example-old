using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerInstantiateSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entity playerPrefab = new Entity();
        Entities.ForEach((GlobalsComponent globals) => {
                playerPrefab = globals.playerPrefab;
            });

        Entities.WithNone<ViewComponent>().ForEach((Entity entity, ref PlayerComponent playerComponent) => {
                var instantiatedPrefab = EntityManager.Instantiate(playerPrefab);
                EntityManager.AddComponent<ViewComponent>(entity);
                EntityManager.SetComponentData<ViewComponent>(entity, new ViewComponent{ entity = instantiatedPrefab });
            });
    }
}
