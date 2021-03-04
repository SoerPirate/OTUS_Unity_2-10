using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class EnemyMoveToStartPositionSystem : IExecuteSystem
{
    IGroup<GameEntity> enemy;

    List<GameEntity> _enemy = new List<GameEntity>();

    public float distanceFromTarget = 0.0f, speed;

    public Vector3 targetPosition, myPosition, distance, direction, step, myStartPosition;

    Animator animator;

    public EnemyMoveToStartPositionSystem(Contexts contexts)
    {
        enemy = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.ICurrentEnemy, 
        GameMatcher.StartPosition, GameMatcher.Speed, 
        GameMatcher.IAlive)); 
    }

    public void Execute()
    {       
        _enemy.Clear();

        foreach (var e in enemy)
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

        _enemy.Add(e);
        }

        foreach (var e in _enemy)
        {
            if (e.hasStartPosition && myPosition == targetPosition)         
            {
            e.RemoveStartPosition();

            speed = 0.0f;
            animator = e.view.gameObject.GetComponentInChildren<Animator>();
            animator.SetFloat("Speed", speed);

            e.RemoveSpeed();

            e.isICurrentEnemy = false;

            e.myGameController.gameController.GetComponent<GameController>().EnemyNextEnemy();

            e.myGameController.gameController.GetComponent<GameController>().enemyTurn = false;
            }
        }
    }
}
