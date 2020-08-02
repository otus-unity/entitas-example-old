using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using TMPro;

public class GlobalsComponentAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject shotPrefab;
    public TextMeshProUGUI enemyCountText;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var component = new GlobalsComponent();
        component.playerPrefab = conversionSystem.GetPrimaryEntity(playerPrefab);
        component.enemyPrefab = conversionSystem.GetPrimaryEntity(enemyPrefab);
        component.shotPrefab = conversionSystem.GetPrimaryEntity(shotPrefab);
        component.enemyCountText = enemyCountText;
        dstManager.AddSharedComponentData(entity, component);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(playerPrefab);
        referencedPrefabs.Add(enemyPrefab);
        referencedPrefabs.Add(shotPrefab);
    }
}
