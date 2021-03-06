using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FillPlayersListInGameControllerSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    public List<GameObject> playersListGO = new List<GameObject>();
    public List<GameEntity> _playersList = new List<GameEntity>();

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
                if (e.isIAlive == true)
                {
                playersListGO.Add(e.view.gameObject);
                _playersList.Add(e);
                }
            }

            foreach (var e in _playersList)
            {
                if (e.isIAlive == true)
                e.view.gameObject.GetComponent<EntitasEntity>().gameController.GetComponent<GameController>().playersGO = playersListGO;
            }
        }
    }
}
