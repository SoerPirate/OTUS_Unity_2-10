using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EndGameSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    //List<Entity> deadEntities = new List<Entity>();
    Contexts contexts;

    public EndGameSystem(Contexts contexts)
    {
        this.contexts = contexts;

        entities = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
        foreach (var e in entities) 
        {
            var x = entities.count;

            if (x == 0)
                Debug.Log("Player Win");
        }    
    }
}
