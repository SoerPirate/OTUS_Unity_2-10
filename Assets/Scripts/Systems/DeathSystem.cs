﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class DeathSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    List<Entity> deadEntities = new List<Entity>();
    Contexts contexts;

    public DeathSystem(Contexts contexts)
    {
        this.contexts = contexts;
        
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

                contexts.game.globals.needFindCurrentPlayer = true;  
                contexts.game.globals.needFindCurrentEnemy = true;
                contexts.game.globals.needFindPlayerTarget = true;
                contexts.game.globals.needFindEnemyTarget = true;
            }
        }

        foreach (var e in deadEntities)
        {
            e.Destroy();
            // не удалять E
        }    
    }
}
