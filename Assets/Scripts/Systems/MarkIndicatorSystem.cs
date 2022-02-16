﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MarkIndicatorSystem : IExecuteSystem // переделать через подписку, как уничтожение индикатора
{
    IGroup<GameEntity> entities;
    GameEntity _enemyTarget;
    Contexts contexts;
    TargetIndicator targetIndicator;
    CurrentPlayerIndicator currentIndicator;
    
    public MarkIndicatorSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.EnemyTarget);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            _enemyTarget = e.enemyTarget.enemyTarget;
            targetIndicator = _enemyTarget.view.gameObject.GetComponentInChildren<TargetIndicator>(true);           
            targetIndicator.SetActiveTrue();   
        }
    }
}