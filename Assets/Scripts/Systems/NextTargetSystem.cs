using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class NextTargetSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    TargetIndicator targetIndicator;
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
            //Debug.Log(entities.count);
            var x = entities.count;

            if (contexts.game.globals.nextTargetButton == true)
            {
                if (i == contexts.game.globals.currentEnemyIndex)
                {
                    targetIndicator = e.view.gameObject.GetComponentInChildren<TargetIndicator>(true);
                    targetIndicator.SetActiveFalse();
                    contexts.game.globals.playerTarget = null;
                    contexts.game.globals.needFillPlayerTarget = true; 
                }

                if (i == contexts.game.globals.currentEnemyIndex + 1)
                {
                    if (i>x-1)
                        i=0;
                    //e.isCurrentEnemy = true;
                    contexts.game.globals.currentEnemyIndex = i;

                    //targetIndicator = contexts.game.globals.playerTarget.view.gameObject.GetComponentInChildren<TargetIndicator>(true);
                    //targetIndicator.SetActiveFalse(); 

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
