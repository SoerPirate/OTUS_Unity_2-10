using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class NextEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> JudgeGameLoopEntity;
    IGroup<GameEntity> enemiesEntities;
    public int _enemyCount, zh; 
    List<GameEntity> _JudgeGameLoopEntity = new List<GameEntity>();
    List<GameEntity> _enemiesEntities = new List<GameEntity>();

    public NextEnemySystem(Contexts contexts)
    {
        JudgeGameLoopEntity = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.JudgeGameLoop, GameMatcher.FindNextEnemy));  
        enemiesEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.IAlive, GameMatcher.FindNextEnemy));                       
    }   

    public void Execute()
    {   
        zh = 1;

        _JudgeGameLoopEntity.Clear();

        foreach (var e in JudgeGameLoopEntity)
        {
            _enemyCount = e.judgeGameLoop.enemyCount;
            _JudgeGameLoopEntity.Add(e);
        }

        _enemiesEntities.Clear();
        
        foreach (var e in enemiesEntities) 
        {
            _enemiesEntities.Add(e);
        }

        if (_enemyCount < _enemiesEntities.Count)
        _enemyCount++; // = 2
        else
        _enemyCount = 1; 

        foreach (var e in _JudgeGameLoopEntity)
        {
           e.judgeGameLoop.enemyCount = _enemyCount;
           e.isFindNextEnemy = false;                                  
        }

        foreach (var e in _enemiesEntities) 
        {
            e.isFindNextEnemy = false;
            if (zh == _enemyCount)
            {
            e.isICurrentEnemy = true;
            //zh = 1;
            }
            if (zh < _enemiesEntities.Count)
                zh++; // = 2
            else
                zh = 1; 
            // else
            // zh++; // тоже надо обнулять?
        }            
    }
}
