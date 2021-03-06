using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MarkEnemySystem : IExecuteSystem
{
    Animator animator;
    IGroup<GameEntity> entities;
    List<GameEntity> _entities = new List<GameEntity>();

    public MarkEnemySystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.ICurrentPlayer, GameMatcher.HitTarget, GameMatcher.IAlive)); 
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
            var vp = e.hitTarget.hitTarget; 
            if (vp.hasView)
            e.hitTarget.hitTarget.view.gameObject.GetComponent<EntitasEntity>().MarkOn();
        }
    }
}