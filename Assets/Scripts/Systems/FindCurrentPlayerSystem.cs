using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FindCurrentPlayerSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    int i=0;

    public FindCurrentPlayerSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Player);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (i<1) // if (contexts.game.globals.needFindCurrentPlayer == true) & (!e.IsDead);
            {   
                if (!e.isCurrentPlayer)
                {
                    e.isCurrentPlayer = true;
                    contexts.game.globals.currentPlayer = e;
                    contexts.game.globals.enemyTarget = e;
                    // contexts.game.globals.needFindCurrentPlayer == false
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
