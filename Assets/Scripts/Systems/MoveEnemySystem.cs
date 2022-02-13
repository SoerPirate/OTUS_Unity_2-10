using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    public MoveEnemySystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.CurrentEnemy);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (contexts.game.globals.nowEnemуTurn == true)
            {
                // движение
                e.isEnemyAttack = true;       // надо доработать AttackEnemySystem
                contexts.game.globals.nowEnemуTurn = false;
            }
        }
    }
}
