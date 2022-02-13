using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FillPlayerTargetSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;

    public FillPlayerTargetSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.Player, 
            GameMatcher.CurrentPlayer));
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (contexts.game.globals.needFindPlayerTarget == true)
            {
                if (!e.hasPlayerTarget) 
                    e.AddPlayerTarget(contexts.game.globals.playerTarget);
                else
                    e.ReplacePlayerTarget(contexts.game.globals.playerTarget);

                contexts.game.globals.needFindPlayerTarget = false;  
            } 
        }
    }
}
