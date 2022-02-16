﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MarkPlayerOffSystem : IInitializeSystem, ITearDownSystem
{
    IGroup<GameEntity> group;
    TargetIndicator targetIndicator;
    CurrentPlayerIndicator currentIndicator;

    public MarkPlayerOffSystem(Contexts contexts)
    {
        group = contexts.game.GetGroup(GameMatcher.CurrentPlayer);
    }

    public void Initialize()
    {
        group.OnEntityRemoved += OnCurrentPlayerRemoved;
    }

    public void TearDown()
    {
        group.OnEntityRemoved -= OnCurrentPlayerRemoved;
    }

    void OnCurrentPlayerRemoved(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
    {
        //var view = (ViewComponent)component;
        //targetIndicator = entity.view.gameObject.GetComponentInChildren<TargetIndicator>(true);
        //targetIndicator.SetActiveFalse(); 

        currentIndicator = entity.view.gameObject.GetComponentInChildren<CurrentPlayerIndicator>(true);           
        currentIndicator.SetActiveTrue();  
    }
}
