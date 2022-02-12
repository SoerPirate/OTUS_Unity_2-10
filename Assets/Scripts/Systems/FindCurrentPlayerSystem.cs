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
            if (i<1)
            {
                e.isCurrentPlayer = true;
                contexts.game.ReplaceGlobals(0.0f, e, null, null, null, false, false); 
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
