using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class NextTargetNoButtonSystem : IExecuteSystem
{
    IGroup<GameEntity> JudgeGameLoopEntity;
    IGroup<GameEntity> playersEntities;
    IGroup<GameEntity> enemiesEntities;

    public GameEntity needThisEnemy;

    List<GameEntity> _JudgeGameLoopEntity = new List<GameEntity>();
    List<GameEntity> _playersEntities = new List<GameEntity>();
    List<GameEntity> _enemiesEntities = new List<GameEntity>();

    public int _enemyCount, zh; 

    public NextTargetNoButtonSystem(Contexts contexts)
    {
        JudgeGameLoopEntity = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.JudgeGameLoop, GameMatcher.NextTargetNoButton));  
        playersEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.IAlive, GameMatcher.NextTargetNoButton));            
        enemiesEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.IAlive, GameMatcher.NextTargetNoButton));             
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
           e.isNextTargetNoButton = false;                                  
        }

        foreach (var e in _enemiesEntities) {
            e.isNextTargetNoButton = false;
            if (zh == _enemyCount)
            {
            needThisEnemy = e;
            zh = 1;
            }
            else
            zh++;
        }
        
        _playersEntities.Clear();

        foreach (var e in playersEntities) 
        {
            _playersEntities.Add(e);
        }

        foreach (var e in _playersEntities) 
        {
            if (e.hasHitTarget)
            {
            //e.hitTarget.hitTarget.view.gameObject.GetComponent<EntitasEntity>().MarkOff();
            e.ReplaceHitTarget(needThisEnemy.position.value, needThisEnemy); 
            }
            else
            e.AddHitTarget(needThisEnemy.position.value, needThisEnemy); 
   
            e.isNextTargetNoButton = false;            
        }        
    }
}