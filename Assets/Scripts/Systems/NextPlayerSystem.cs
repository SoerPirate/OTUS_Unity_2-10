using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class NextPlayerSystem : IExecuteSystem
{
    IGroup<GameEntity> JudgeGameLoopEntity;
    IGroup<GameEntity> playersEntities;
    public int _playerCount, zh; 
    List<GameEntity> _JudgeGameLoopEntity = new List<GameEntity>();
    List<GameEntity> _playersEntities = new List<GameEntity>();

    public NextPlayerSystem(Contexts contexts)
    {
        JudgeGameLoopEntity = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.JudgeGameLoop, GameMatcher.FindNextPlayer));  
        playersEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.IAlive, GameMatcher.FindNextPlayer));                       
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
        _playerCount++; // = 2
        else
        _playerCount = 1; 

        foreach (var e in _JudgeGameLoopEntity){
           e.judgeGameLoop.playerCount = _playerCount;
           e.isFindNextPlayer = false;                                  
        }

        foreach (var e in _playersEntities) {
            e.isFindNextPlayer = false;
            if (zh == _playerCount)
            {
            e.isICurrentPlayer = true;
            zh = 1;
            }
            else
            zh++; // тоже надо обнулять?
        }
    }
}
