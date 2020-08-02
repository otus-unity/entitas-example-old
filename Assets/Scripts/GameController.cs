using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject shotPrefab;
    public TextMeshProUGUI enemyCountText;
    Systems systems;

    void Awake()
    {
        var contexts = Contexts.sharedInstance;

        contexts.game.SetGlobals(playerPrefab, enemyPrefab, shotPrefab, enemyCountText);

        systems = new Systems();
        systems.Add(new DeathSystem(contexts));
        systems.Add(new PlayerInstantiateSystem(contexts));
        systems.Add(new ShotInstantiateSystem(contexts));
        systems.Add(new EnemyInstantiateSystem(contexts));
        systems.Add(new ShotMovementSystem(contexts));
        systems.Add(new ShotCollisionSystem(contexts));
        systems.Add(new EnemyMovementSystem(contexts));
        systems.Add(new PlayerInputSystem(contexts));
        systems.Add(new ViewDestroySystem(contexts));
        systems.Add(new TransformApplySystem(contexts));
        systems.Initialize();
    }

    void OnDestroy()
    {
        systems.TearDown();
    }

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
