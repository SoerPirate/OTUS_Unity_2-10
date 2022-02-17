using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EnemyTargIndFalseSystem : IInitializeSystem, ITearDownSystem
{
    IGroup<GameEntity> group;
    CurrentPlayerIndicator currentIndicator;

    public EnemyTargIndFalseSystem(Contexts contexts)
    {
        group = contexts.game.GetGroup(GameMatcher.CurrentEnemy);
    }

    public void Initialize()
    {
        group.OnEntityRemoved += OnCurrentEnemyRemoved;
    }

    public void TearDown()
    {
        group.OnEntityRemoved -= OnCurrentEnemyRemoved;
    }

    void OnCurrentEnemyRemoved(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
    {
        currentIndicator = entity.view.gameObject.GetComponentInChildren<CurrentPlayerIndicator>(true);           
        currentIndicator.SetActiveTrue(); 
    }
}
