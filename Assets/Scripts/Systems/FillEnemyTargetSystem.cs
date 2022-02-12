using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FillEnemyTargetSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;

    public FillEnemyTargetSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.Enemy,                                  // можно убрать
            GameMatcher.CurrentEnemy));
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (!e.hasEnemyTarget)
                e.AddEnemyTarget(contexts.game.globals.enemyTarget);       
        }
    }
}
