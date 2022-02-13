using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FindCurrentPlayerSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;

    public FindCurrentPlayerSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Player);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (contexts.game.globals.needFindCurrentPlayer == true)
            {   
                if (e.isCurrentPlayer)
                    break;
                else
                {
                    e.isCurrentPlayer = true;
                    contexts.game.globals.currentPlayer = e;
                    contexts.game.globals.enemyTarget = e;
                }

                contexts.game.globals.needFindCurrentPlayer = false;
            }
        }
    }
}
