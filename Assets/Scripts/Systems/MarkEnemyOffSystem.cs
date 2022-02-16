using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MarkEnemyOffSystem : IInitializeSystem, ITearDownSystem
{
    IGroup<GameEntity> group;
    TargetIndicator targetIndicator;
    GameEntity _enemyTarget;

    public MarkEnemyOffSystem(Contexts contexts)
    {
        group = contexts.game.GetGroup(GameMatcher.EnemyTarget);
    }

    public void Initialize()
    {
        group.OnEntityRemoved += OnEnemyTargetRemoved;
    }

    public void TearDown()
    {
        group.OnEntityRemoved -= OnEnemyTargetRemoved;
    }

    void OnEnemyTargetRemoved(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
    {
        _enemyTarget = entity.enemyTarget.enemyTarget;
        targetIndicator = _enemyTarget.view.gameObject.GetComponentInChildren<TargetIndicator>(true);           
        targetIndicator.SetActiveFalse();
    }
}

