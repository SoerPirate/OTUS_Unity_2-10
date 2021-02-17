﻿using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class NextTargetSystem : IExecuteSystem
{
    IGroup<GameEntity> JudgeGameLoopEntity;
    IGroup<GameEntity> playersEntities;
    IGroup<GameEntity> enemiesEntities;

    public GameEntity needThisEnemy;

    //public bool needOnlyOne = true;

    List<GameEntity> _JudgeGameLoopEntity = new List<GameEntity>();
    List<GameEntity> _playersEntities = new List<GameEntity>();
    List<GameEntity> _enemiesEntities = new List<GameEntity>();

    public int _enemyCount, zh; 

    public NextTargetSystem(Contexts contexts)
    {
        JudgeGameLoopEntity = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.JudgeGameLoop, GameMatcher.NextTarget)); 
        playersEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.NextTarget));
        enemiesEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.NextTarget));
    }

    public void Execute()
    {   
        zh = 1;

        _JudgeGameLoopEntity.Clear();

        foreach (var e in JudgeGameLoopEntity){
            _enemyCount = e.judgeGameLoop.enemyCount;
            _JudgeGameLoopEntity.Add(e);
        }

        _enemiesEntities.Clear();
        
        foreach (var e in enemiesEntities) {
            _enemiesEntities.Add(e);
        }

        foreach (var e in _enemiesEntities) {
            e.isNextTarget = false;
            //if (needThisEnemy == null)
            if (zh == _enemyCount)
            needThisEnemy = e;
            zh++;
        }

        //needThisEnemy = _enemiesEntities[0];              // что со счетчиком? 

        _enemyCount++;

        foreach (var e in _JudgeGameLoopEntity){
           e.judgeGameLoop.enemyCount = _enemyCount;
           e.isNextTarget = false;                                  
        }
        
        _playersEntities.Clear();

        foreach (var e in playersEntities) {
            _playersEntities.Add(e);
        }

        foreach (var e in _playersEntities) {
            if (e.hasMoveTarget)
            e.ReplaceMoveTarget(needThisEnemy.position.value); 
            else
            e.AddMoveTarget(needThisEnemy.position.value);          // + Remove

            e.isNextTarget = false;
        }
        
        //подтянуть судью ходов. положить ентити врагов в другой список, 
        //взять из него врага с индексом (узнать у судьи), судье сдвинуть индекс +1
        
    }
}