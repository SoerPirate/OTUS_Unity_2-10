using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MarkIndicatorPLSystem : IExecuteSystem // переделать через подписку, как уничтожение индикатора
{
    IGroup<GameEntity> entities;
    GameEntity _playerTarget;
    Contexts contexts;
    TargetIndicator targetIndicator;
    CurrentPlayerIndicator currentIndicator;
    
    public MarkIndicatorPLSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.PlayerTarget);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            _playerTarget = e.playerTarget.playerTarget;
            targetIndicator = _playerTarget.view.gameObject.GetComponentInChildren<TargetIndicator>(true);           
            targetIndicator.SetActiveTrue();     
        }
    }
}
