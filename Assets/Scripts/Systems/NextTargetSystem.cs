using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class NextTargetSystem : IExecuteSystem
{
    IGroup<GameEntity> JudgeGameLoopEntity;
    IGroup<GameEntity> playersEntities;
    IGroup<GameEntity> enemiesEntities;

    public GameEntity needThisEnemy;

    List<GameEntity> _JudgeGameLoopEntity = new List<GameEntity>();
    List<GameEntity> _playersEntities = new List<GameEntity>();
    List<GameEntity> _enemiesEntities = new List<GameEntity>();

    public int _enemyCount, zh; 

    public NextTargetSystem(Contexts contexts)
    {
        JudgeGameLoopEntity = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.JudgeGameLoop, GameMatcher.NextTarget));  
        playersEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.IAlive, GameMatcher.NextTarget));            
        enemiesEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.IAlive, GameMatcher.NextTarget));             
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

        //needThisEnemy = _enemiesEntities[0];              // что со счетчиком? 
        if (_enemyCount < _enemiesEntities.Count)
        _enemyCount++;
        else
        _enemyCount = 1;                             

        foreach (var e in _JudgeGameLoopEntity){
           e.judgeGameLoop.enemyCount = _enemyCount;
           e.isNextTarget = false;                                  
        }

        foreach (var e in _enemiesEntities) {
            e.isNextTarget = false;
            if (zh == _enemyCount)
            needThisEnemy = e;
            zh++;
        }
        
        _playersEntities.Clear();

        foreach (var e in playersEntities) {
            _playersEntities.Add(e);
        }

        foreach (var e in _playersEntities) 
        {
            if (e.hasHitTarget)
            e.ReplaceHitTarget(needThisEnemy.position.value, needThisEnemy); 
            else
            e.AddHitTarget(needThisEnemy.position.value, needThisEnemy); 
   
            e.isNextTarget = false;            
        }        
    }
}