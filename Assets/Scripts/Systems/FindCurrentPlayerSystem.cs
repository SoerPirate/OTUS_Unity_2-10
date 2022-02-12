using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FindCurrentPlayerSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    //List<Entity> deadEntities = new List<Entity>();

    public FindCurrentPlayerSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.Player);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            
        }
    }
}
