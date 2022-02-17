using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ChangeDeadPlayerSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;

    public ChangeDeadPlayerSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Player);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (contexts.game.globals.changeDeadPlayer == true)
            {
                contexts.game.globals.enemyTarget = e;
                contexts.game.globals.changeDeadPlayer = false;
            }  
        }
    }
}
