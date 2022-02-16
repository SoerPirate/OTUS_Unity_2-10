using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MarkPlayerOffSystem : IInitializeSystem, ITearDownSystem
{
    IGroup<GameEntity> group;
    TargetIndicator targetIndicator;
    GameEntity _playerTarget;

    public MarkPlayerOffSystem(Contexts contexts)
    {
        group = contexts.game.GetGroup(GameMatcher.PlayerTarget);
    }

    public void Initialize()
    {
        group.OnEntityRemoved += OnPlayerTargetRemoved;
    }

    public void TearDown()
    {
        group.OnEntityRemoved -= OnPlayerTargetRemoved;
    }

    void OnPlayerTargetRemoved(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
    {
        _playerTarget = entity.playerTarget.playerTarget;
        targetIndicator = _playerTarget.view.gameObject.GetComponentInChildren<TargetIndicator>(true);
        targetIndicator.SetActiveFalse(); 
    }
}
