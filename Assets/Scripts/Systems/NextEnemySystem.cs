using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class NextEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> JudgeGameLoopEntity;
    IGroup<GameEntity> enemiesEntities;

    public GameEntity needThisEnemy;

    List<GameEntity> _JudgeGameLoopEntity = new List<GameEntity>();
    List<GameEntity> _enemiesEntities = new List<GameEntity>();

    public NextEnemySystem(Contexts contexts)
    {
        JudgeGameLoopEntity = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.JudgeGameLoop, GameMatcher.FindNextEnemy));  
        enemiesEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.IAlive, GameMatcher.FindNextEnemy));                       
    }   

    public void Execute()
    {   
                
    }
}
