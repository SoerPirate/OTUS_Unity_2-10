using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FindCurrentEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;

    public FindCurrentEnemySystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (contexts.game.globals.needFindCurrentEnemy == true)
            {
                if (!e.isCurrentEnemy)
                {
                    e.isCurrentEnemy = true;
                    contexts.game.globals.currentEnemy = e;
                    contexts.game.globals.playerTarget = e;
                    contexts.game.globals.needFindCurrentEnemy = false;
                }
            }                
        }
    }
}
