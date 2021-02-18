using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveToSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    
    public float distanceFromTarget = 0.5f, speed;

    public Vector3 targetPosition, myPosition, distance, direction, step;

    public MoveToSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MoveTarget, GameMatcher.Speed));  // Attack
    }

    public void Execute()
    {
        
        foreach (var e in entities)
        {
        
        targetPosition = e.moveTarget.targetPosition;

        myPosition = e.position.value;

        distance = targetPosition - myPosition;

        speed = e.speed.value;

            if (distance.magnitude < 0.00001f) 
            myPosition = targetPosition;
            else
            {
            direction = distance.normalized;
            //transform.rotation = Quaternion.LookRotation(direction);

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

        }

    }
}
