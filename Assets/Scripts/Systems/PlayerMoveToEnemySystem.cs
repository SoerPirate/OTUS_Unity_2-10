﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PlayerMoveToEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> entities;

    List<GameEntity> _entities = new List<GameEntity>();
    
    public float distanceFromTarget = 0.0f, speed;

    public Vector3 targetPosition, myPosition, distance, direction, step, myStartPosition;

    Animator animator;

    public int msp = 1;

    public PlayerMoveToEnemySystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.ICurrentPlayer,  
        GameMatcher.MoveTarget, GameMatcher.HitTarget, GameMatcher.Speed, 
        GameMatcher.IAlive)); 
    }

    public void Execute()
    {
        _entities.Clear();

        foreach (var e in entities)
        {

        if (msp == 1)
        {
            myStartPosition = e.position.value;
            msp++;
        }

        targetPosition = e.moveTarget.targetPosition;

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

        _entities.Add(e);
        }

        foreach (var e in _entities)
        {
            if (e.hasMoveTarget && myPosition == targetPosition)         
            {
            e.RemoveMoveTarget();

            speed = 0.0f;
            animator = e.view.gameObject.GetComponentInChildren<Animator>();
            animator.SetFloat("Speed", speed);

            e.RemoveSpeed();

            e.AddStartPosition(myStartPosition);

            //myStartPosition = myStartPosition;

            myStartPosition = new Vector3(0,0,0);

            msp = 1;

            e.isAttack = true;
            }
        }
    }
}
