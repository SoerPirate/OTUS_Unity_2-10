using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FillEnemiesListInGameControllerSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    public List<GameObject> enemiesListGO = new List<GameObject>();
    public List<GameEntity> _enemiesList = new List<GameEntity>();

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
            Debug.Log("Когда не останется врагов. Почему система продолжает работать, хотя GameMatcher.Enemy,GameMatcher.View,GameMatcher.IAlive больше нет?");

            foreach (var e in entities)
            {
                if (e.isIAlive == true)
                {
                enemiesListGO.Add(e.view.gameObject);
                _enemiesList.Add(e);
                }
            }

            foreach (var e in _enemiesList)
            {
                if (e.isIAlive == true)
                e.view.gameObject.GetComponent<EntitasEntity>().gameController.GetComponent<GameController>().enemiesGO = enemiesListGO; 
            }
        }
    }
}
