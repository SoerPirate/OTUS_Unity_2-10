using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class DeathSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    List<Entity> deadEntities = new List<Entity>();

    public DeathSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.Health, 
            GameMatcher.View));
    }

    public void Execute()
    {
        deadEntities.Clear();

        foreach (var e in entities) 
        {
            if (e.health.value <= 0)
            {
                deadEntities.Add(e); // будет ненужен
                // добавлять IDeadComponent
                GameObject.Destroy(e.view.gameObject);
            }
        }

        foreach (var e in deadEntities)
        {
            e.Destroy();
            // не удалять E
        }    
    }
}
