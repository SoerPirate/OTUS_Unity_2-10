using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    List<GameEntity> deadEntities = new List<GameEntity>();

    public PlayerCollisionSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Health, GameMatcher.DetectedCollision));
    }

    public void Execute()
    {
        deadEntities.Clear();
        foreach (var e in entities) {
            e.health.value -= 1.0f;
            deadEntities.Add(e);
        }

        foreach (var e in deadEntities)
            e.isDetectedCollision = false;
    }
}
