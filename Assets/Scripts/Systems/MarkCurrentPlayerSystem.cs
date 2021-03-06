using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MarkCurrentPlayerSystem : IExecuteSystem
{
    Animator animator;
    IGroup<GameEntity> entities;
    List<GameEntity> _entities = new List<GameEntity>();

    public MarkCurrentPlayerSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.ICurrentPlayer, GameMatcher.IAlive)); 
    }

    public void Execute()
    {
        _entities.Clear();

        foreach (var e in entities) 
        {
            _entities.Add(e);
        }

        foreach (var e in _entities) 
        {
            if (e.hasView)
            e.view.gameObject.GetComponent<EntitasEntity>().CIOn();
        }
    }
}