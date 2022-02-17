using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ChangeDeadEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;

    public ChangeDeadEnemySystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (contexts.game.globals.changeDeadEnemy == true)
            {
                contexts.game.globals.playerTarget = e;
                contexts.game.globals.changeDeadEnemy = false;
            }             
        }
    }
}
