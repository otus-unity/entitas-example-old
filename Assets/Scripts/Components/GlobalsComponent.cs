using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Entities;
using TMPro;

public struct GlobalsComponent : ISharedComponentData, IEquatable<GlobalsComponent>
{
    public Entity playerPrefab;
    public Entity enemyPrefab;
    public Entity shotPrefab;
    public TextMeshProUGUI enemyCountText;

    public bool Equals(GlobalsComponent other)
    {
        return playerPrefab == other.playerPrefab
            && enemyPrefab == other.enemyPrefab
            && shotPrefab == other.shotPrefab
            && enemyCountText == other.enemyCountText;
    }

    public override int GetHashCode()
    {
        // FIXME
        return playerPrefab.GetHashCode();
    }
}
