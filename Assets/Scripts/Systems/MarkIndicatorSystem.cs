using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MarkIndicatorSystem : IExecuteSystem // переделать через подписку, как уничтожение индикатора
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    TargetIndicator targetIndicator;
    CurrentPlayerIndicator currentIndicator;
    public MarkIndicatorSystem(Contexts contexts)
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
            //targetIndicator = e.view.gameObject.GetComponentInChildren<TargetIndicator>(true);           
            //targetIndicator.SetActiveTrue(); 

            currentIndicator = e.view.gameObject.GetComponentInChildren<CurrentPlayerIndicator>(true);           
            currentIndicator.SetActiveTrue();     
        }
    }
}
