﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class PlayerInputSystem : IExecuteSystem
{
    Contexts contexts;
    IGroup<GameEntity> entities;

    public PlayerInputSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Player);
    }

    public void Execute()
    {
        foreach (var e in entities) {
            // position

            float positionDelta = 0.0f;
            if (Input.GetKey(KeyCode.W))
                positionDelta += 1.0f;
            if (Input.GetKey(KeyCode.S))
                positionDelta -= 1.0f;

            if (!Mathf.Approximately(positionDelta, 0.0f)) {
                var angle = e.rotation.angle * Mathf.Deg2Rad;
                var dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                e.ReplacePosition(e.position.value + dir * 10.0f * Time.deltaTime * positionDelta);
            }

            // rotation

            float rotationDelta = 0.0f;
            if (Input.GetKey(KeyCode.A))
                rotationDelta += 1.0f;
            if (Input.GetKey(KeyCode.D))
                rotationDelta -= 1.0f;

            if (!Mathf.Approximately(rotationDelta, 0.0f))
                e.ReplaceRotation(e.rotation.angle + rotationDelta * 120.0f * Time.deltaTime);

            // shooting

            if (Input.GetMouseButtonDown(0)) {
                var angle = e.rotation.angle * Mathf.Deg2Rad;
                var dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                var entity = contexts.game.CreateEntity();
                entity.isShot = true;
                entity.AddPosition(e.position.value + dir);
                entity.AddRotation(e.rotation.angle);
            }
        }
    }
}
*/
