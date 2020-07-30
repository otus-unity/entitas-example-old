using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Unique]
public class GlobalsComponent : IComponent
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject shotPrefab;
}
