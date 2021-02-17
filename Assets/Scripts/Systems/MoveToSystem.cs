using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveToSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    
    public float distanceFromTarget = 0.5f;

    public Vector3 targetPosition, myPosition, distance;

    public MoveToSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.MoveTarget);
    }

    public void Execute()
    {
        
        foreach (var e in entities)
        {
        
        targetPosition = e.moveTarget.targetPosition;

        myPosition = e.position.value;

        /*
        distance = targetPosition - myPosition;
        if (distance.magnitude < 0.00001f) {
            myPosition = targetPosition;
            return true;
        }

        Vector3 direction = distance.normalized;
        transform.rotation = Quaternion.LookRotation(direction);

        targetPosition -= direction * distanceFromTarget;
        distance = (targetPosition - myPosition);

        Vector3 step = direction * runSpeed;
        if (step.magnitude < distance.magnitude) {
            myPosition += step;
            return false;
        }

        myPosition = targetPosition;
        return true;
        */

        }

    }
}
