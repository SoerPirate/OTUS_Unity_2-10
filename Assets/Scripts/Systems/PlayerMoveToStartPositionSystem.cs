using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class PlayerMoveToStartPositionSystem : IExecuteSystem
{
    IGroup<GameEntity> player;

    List<GameEntity> _player = new List<GameEntity>();

    public float distanceFromTarget = 0.0f, speed;

    public Vector3 targetPosition, myPosition, distance, direction, step, myStartPosition;

    Animator animator;

    public PlayerMoveToStartPositionSystem(Contexts contexts)
    {
        player = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.ICurrentPlayer, 
        GameMatcher.StartPosition, GameMatcher.Speed, 
        GameMatcher.IAlive)); 
    }

    public void Execute()
    {       
        _player.Clear();

        foreach (var e in player)
        {
        myStartPosition = e.position.value;

        targetPosition = e.startPosition.startPosition;

        myPosition = e.position.value;

        distance = targetPosition - myPosition;

        speed = e.speed.value;

        animator = e.view.gameObject.GetComponentInChildren<Animator>();
        animator.SetFloat("Speed", speed);

            if (distance.magnitude < 0.00001f) 
            myPosition = targetPosition;
            else
            {
            direction = distance.normalized;

            targetPosition -= direction * distanceFromTarget;
            distance = (targetPosition - myPosition);

            step = direction * speed * Time.deltaTime;
                if (step.magnitude < distance.magnitude) 
                myPosition += step;
                else
                myPosition = targetPosition;
            }

        e.position.value = myPosition;
        e.view.gameObject.transform.position = myPosition;

        _player.Add(e);
        }

        foreach (var e in _player)
        {
            if (e.hasStartPosition && myPosition == targetPosition)         
            {
            e.RemoveStartPosition();

            speed = 0.0f;
            animator = e.view.gameObject.GetComponentInChildren<Animator>();
            animator.SetFloat("Speed", speed);

            e.RemoveSpeed();

            e.isICurrentPlayer = false;
            e.view.gameObject.GetComponent<EntitasEntity>().CIOff();

            //e.myGameController.gameController.GetComponent<GameController>().NextPlayer();

            e.myGameController.gameController.GetComponent<GameController>().playerTurn = false;
            e.myGameController.gameController.GetComponent<GameController>().enemyTurn = true;

            e.myGameController.gameController.GetComponent<GameController>().EnemyTurn();
            }
        }
    }
}
