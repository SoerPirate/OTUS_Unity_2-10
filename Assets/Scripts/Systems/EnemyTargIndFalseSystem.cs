using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EnemyTargIndFalseSystem : IInitializeSystem, ITearDownSystem
{
    IGroup<GameEntity> group;
    TargetIndicator targetIndicator;

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
        //var view = (ViewComponent)component;
        targetIndicator = entity.view.gameObject.GetComponentInChildren<TargetIndicator>(true);
        targetIndicator.SetActiveFalse();  
    }
}
