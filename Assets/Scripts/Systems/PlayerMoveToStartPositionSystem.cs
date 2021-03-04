using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class PlayerMoveToStartPositionSystem : IExecuteSystem
{
    IGroup<GameEntity> player, players, judge;

    List<GameEntity> _player = new List<GameEntity>();
    List<GameEntity> _players = new List<GameEntity>();
    List<GameEntity> _judge = new List<GameEntity>();

    public PlayerMoveToStartPositionSystem(Contexts contexts)
    {
        player = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.ICurrentPlayer, 
        GameMatcher.StartPosition, GameMatcher.Speed, 
        GameMatcher.IAlive)); 

        judge = contexts.game.GetGroup(GameMatcher.JudgeGameLoop);  

        players = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.IAlive));
    }

    public void Execute()
    {       
        foreach (var e in player)
        {
            e.isDebug2 = true;
        }
    //     _entities.Clear();

    //     foreach (var e in entities)
    //     {
    //     myStartPosition = e.position.value;

    //     targetPosition = e.moveTarget.targetPosition;

    //     myPosition = e.position.value;

    //     distance = targetPosition - myPosition;

    //     speed = e.speed.value;

    //     animator = e.view.gameObject.GetComponentInChildren<Animator>();
    //     animator.SetFloat("Speed", speed);

    //         if (distance.magnitude < 0.00001f) 
    //         myPosition = targetPosition;
    //         else
    //         {
    //         direction = distance.normalized;

    //         targetPosition -= direction * distanceFromTarget;
    //         distance = (targetPosition - myPosition);

    //         step = direction * speed * Time.deltaTime;
    //             if (step.magnitude < distance.magnitude) 
    //             myPosition += step;
    //             else
    //             myPosition = targetPosition;
    //         }

    //     e.position.value = myPosition;
    //     e.view.gameObject.transform.position = myPosition;

    //     _entities.Add(e);
    //     }

    //     foreach (var e in _entities)
    //     {
    //         if (e.hasMoveTarget && myPosition == targetPosition)         
    //         {
    //         e.RemoveMoveTarget();

    //         speed = 0.0f;
    //         animator = e.view.gameObject.GetComponentInChildren<Animator>();
    //         animator.SetFloat("Speed", speed);

    //         e.RemoveSpeed();

    //         e.AddStartPosition(myStartPosition);

    //         e.isAttack = true;
    //         }
    //     }
    }
}
