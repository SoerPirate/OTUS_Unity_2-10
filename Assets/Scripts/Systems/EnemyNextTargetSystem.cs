using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNextTargetSystem : IExecuteSystem
{
    IGroup<GameEntity> JudgeGameLoopEntity;
    IGroup<GameEntity> playersEntities;
    IGroup<GameEntity> enemiesEntities;

    public GameEntity needThisPlayer;

    List<GameEntity> _JudgeGameLoopEntity = new List<GameEntity>();
    List<GameEntity> _playersEntities = new List<GameEntity>();
    List<GameEntity> _enemiesEntities = new List<GameEntity>();

    public int _playerCount, zh; 

    public EnemyNextTargetSystem(Contexts contexts)
    {
        JudgeGameLoopEntity = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.JudgeGameLoop, GameMatcher.EnemyNextTarget));  
        playersEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.IAlive, GameMatcher.EnemyNextTarget));            
        enemiesEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.IAlive, GameMatcher.EnemyNextTarget));             
    }   

    public void Execute()
    {   
        zh = 1;

        _JudgeGameLoopEntity.Clear();

        foreach (var e in JudgeGameLoopEntity){
            _playerCount = e.judgeGameLoop.playerCount;
            _JudgeGameLoopEntity.Add(e);
        }

        _playersEntities.Clear();
        
        foreach (var e in playersEntities) {
            _playersEntities.Add(e);
        }

        if (_playerCount < _playersEntities.Count)
        _playerCount++;
        else
        _playerCount = 1;                             

        foreach (var e in _JudgeGameLoopEntity){
           e.judgeGameLoop.playerCount = _playerCount;
           e.isEnemyNextTarget = false;                                  
        }
        
        foreach (var e in _playersEntities) {
            e.isEnemyNextTarget = false;
            if (zh == _playerCount)
            {
            needThisPlayer = e;
            zh = 1;
            }
            else
            zh++;
        }

        _enemiesEntities.Clear();

        foreach (var e in enemiesEntities) {
            _enemiesEntities.Add(e);
        }

        foreach (var e in _enemiesEntities) 
        {
            if (e.hasHitTarget)
            e.ReplaceHitTarget(needThisPlayer.position.value, needThisPlayer); 
            else
            e.AddHitTarget(needThisPlayer.position.value, needThisPlayer); 
   
            e.isEnemyNextTarget = false;            
        }        
    }
}