using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class DeathSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    List<Entity> deadEntities = new List<Entity>();
    List<GameObject> playersInGameController = new List<GameObject>();

    public DeathSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Health, GameMatcher.IAlive));
    }

    public void Execute()
    {
        deadEntities.Clear();

        foreach (var e in entities) 
        {
            if (e.health.value <= 0)
            {
                deadEntities.Add(e);

                if (e.isPlayer == true)
                    e.myGameController.gameController.GetComponent<GameController>().playersGO.Clear();
                if (e.isEnemy == true)
                    e.myGameController.gameController.GetComponent<GameController>().enemiesGO.Clear();
            }
        }

        foreach (var e in deadEntities)
        {
            //враги не должны исчезать. не удалять, а включать анимацию смерти   
            e.Destroy();
        }    
    }
}
