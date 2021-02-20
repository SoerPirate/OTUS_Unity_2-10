using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FillPlayersListInGameControllerSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    List<GameObject> playersListGO = new List<GameObject>();

    public FillPlayersListInGameControllerSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.Player,
            GameMatcher.View,
            GameMatcher.IAlive));
    }

    public void Execute()
    {
        if (playersListGO.Count == 0)
        {
            foreach (var e in entities)
            {
                playersListGO.Add(e.view.gameObject);
            }

            foreach (var e in entities)
            {
                e.view.gameObject.GetComponent<EntitasEntity>().gameController.GetComponent<GameController>().playersGO = playersListGO;
            }
        }
    }
}
