using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PlayerDeathSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    List<GameEntity> deadEntities;

    public PlayerDeathSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Health));
    }

    public void Execute()
    {
        deadEntities.Clear();

        foreach (var e in entities) 
        {
            if (e.health.value <= 0)
            {
                deadEntities.Add(e);
            }
        }

        foreach (var e in deadEntities)
        {
            //враги не должны исчезать. не удалять, а включать анимацию смерти   
            //e.Destroy();
        }    
    }
}
