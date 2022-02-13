using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class TargetIndicatorSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    TargetIndicator targetIndicator;
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
            targetIndicator = e.view.gameObject.GetComponentInChildren<TargetIndicator>(true);           
            targetIndicator.SetActiveTrue();     
        }
    }
}
