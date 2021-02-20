using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FillEnemiesListInGameControllerSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    List<GameObject> enemiesListGO = new List<GameObject>();

    public FillEnemiesListInGameControllerSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.Enemy,
            GameMatcher.View,
            GameMatcher.IAlive));
    }

    public void Execute()
    {
        if (enemiesListGO.Count == 0)
        {
            foreach (var e in entities)
            {
                enemiesListGO.Add(e.view.gameObject);
            }

            foreach (var e in entities)
            {
                e.view.gameObject.GetComponent<EntitasEntity>().gameController.GetComponent<GameController>().enemiesGO = enemiesListGO;
            }
        }
    }
}
