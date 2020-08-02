using Unity.Entities;

[GenerateAuthoringComponent]
public struct EnemyComponent : IComponentData
{
    public float timeUntilNextTurn;
}
