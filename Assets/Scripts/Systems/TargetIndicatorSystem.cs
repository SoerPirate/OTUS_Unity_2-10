using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class TargetIndicatorSystem : IExecuteSystem // переделать через подписку, как уничтожение индикатора
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    CurrentPlayerIndicator currentIndicator;
    
    public TargetIndicatorSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.AnyOf(
            GameMatcher.CurrentEnemy, 
            GameMatcher.CurrentPlayer));
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            currentIndicator = e.view.gameObject.GetComponentInChildren<CurrentPlayerIndicator>(true);           
            currentIndicator.SetActiveTrue();     
        }
    }
}
