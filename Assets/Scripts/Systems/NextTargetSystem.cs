using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class NextTargetSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    int i=0;
    public NextTargetSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (contexts.game.globals.nextTargetButton == true)
            {
                //if (i == contexts.game.globals.currentEnemyIndex)
                //{
                //    e.isCurrentEnemy = false;  // playerTarget? ОШИБКА мы хотим менять цель у игрока, а не текущего врага
                //}

                if (i == contexts.game.globals.currentEnemyIndex + 1)
                {
                    //e.isCurrentEnemy = true;
                    contexts.game.globals.currentEnemyIndex = i;
                    //contexts.game.globals.currentEnemy = e;
                    contexts.game.globals.playerTarget = e;
                    contexts.game.globals.nextTargetButton = false;
                    //contexts.game.globals.needFillEnemyTarget = true; 
                    contexts.game.globals.needFillPlayerTarget = true;
                    i = 0;
                    break;
                }
                    
                i+=1;
            }                
        }
    }
}
