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
        foreach (var e in entities) {
            if (e.health.value <= 0)
                deadEntities.Add(e);
            e.myGameController.gameController.GetComponent<GameController>().enemiesGO.Clear();
        }

        foreach (var e in deadEntities)
            //e.isIAlive = false;

            //var _myGameController = e.myGameController.gameController;
            //_myGameController.GetComponent<GameController>().enemiesGO.Clear();

            //playersInGameController.Clear();
            
            e.Destroy();
            
    }
}
