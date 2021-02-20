using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveToSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;

    List<GameEntity> _entities = new List<GameEntity>();
    
    public float distanceFromTarget = 0.0f, speed;

    public Vector3 targetPosition, myPosition, distance, direction, step, myStartPosition;

    Animator animator;

    public MoveToSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MoveTarget, GameMatcher.Speed, GameMatcher.Attack, GameMatcher.IAlive)); 
                                                                                                    //, GameMatcher.MyTurn вместо Attack
    }

    public void Execute()
    {
/*
        foreach (var e in entities)
        {
            myStartPosition = e.position.value;
            e.startPosition.value = myStartPosition;
        }
*/

        _entities.Clear();

        foreach (var e in entities)
        {
        animator = e.view.gameObject.GetComponentInChildren<Animator>();
        animator.SetFloat("Speed", speed);

        targetPosition = e.moveTarget.targetPosition;

        myPosition = e.position.value;

        distance = targetPosition - myPosition;

        speed = e.speed.value;

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

        _entities.Add(e);
        }

        foreach (var e in _entities)
        {
            if (e.hasMoveTarget && myPosition == targetPosition)         

                                                //позиция продолжает совпадать . добавить доп условие кроме hasMoveTarget 
                                                //ИЛИ 
                                                //передалть на реактивность 
                                                //ИЛИ 
                                                //убегать от врага (для теста)

            //if (e.hasMoveTarget && e.position.value == targetPosition)
            //if (e.position.value == targetPosition)
            {

            e.isDebug2 = true;

            e.RemoveMoveTarget();
            speed = 0.0f;
            //e.ReplaceSpeed(speed);
            e.RemoveSpeed();
            animator = e.view.gameObject.GetComponentInChildren<Animator>();
            animator.SetFloat("Speed", speed);
            
            //e.AddHitTarget(targetPosition);
            }

        e.isDebug = true;
        }
    }
}
