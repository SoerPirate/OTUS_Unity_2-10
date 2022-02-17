using System.Collections;
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

                // 
                //

                if (e.isEnemy)
                {
                    contexts.game.globals.needFindCurrentEnemy = true;
                    contexts.game.globals.changeDeadEnemy = true;
                    contexts.game.globals.needFillPlayerTarget = true;
                    contexts.game.globals.needFillEnemyTarget = true;
                    contexts.game.globals.currentEnemyIndex = 0;
                    contexts.game.globals.enemyCount -= 1;
                }
                    
                if (e.isPlayer)
                {
                    contexts.game.globals.needFindCurrentPlayer = true; 
                    contexts.game.globals.changeDeadPlayer = true;
                    contexts.game.globals.needFillEnemyTarget = true;
                    contexts.game.globals.needFillPlayerTarget = true;
                    contexts.game.globals.playerCount -= 1;
                } 
            }
        }

        foreach (var e in deadEntities)
        {
            e.Destroy();
            // не удалять E
        }    
    }
}
