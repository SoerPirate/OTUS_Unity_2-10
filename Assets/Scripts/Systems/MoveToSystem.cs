using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveToSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    

    public MoveToSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.Health);
    }

    public void Execute()
    {
        foreach (var e in entities) 
        {
            e.isDebug = true;
        }
    }
}
