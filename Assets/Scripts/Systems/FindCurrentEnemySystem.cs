using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FindCurrentEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    int i=0;

    public FindCurrentEnemySystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (i<1)
            {
                if (!e.isCurrentEnemy)
                {
                    e.isCurrentEnemy = true;
                    contexts.game.globals.currentEnemy = e;
                    contexts.game.globals.playerTarget = e;
                }

                i=1;
            }
            else
            {
                i=0;
                break;
            }
                
        }
    }
}
