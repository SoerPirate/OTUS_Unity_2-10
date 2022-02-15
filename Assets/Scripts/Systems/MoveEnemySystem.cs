using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    Vector3 distance, direction, step, targetPosition, myPosition;
    float runSpeed, distanceFromTarget = 1.2f;
    Quaternion myRotation;
    List<GameEntity> moveEntities = new List<GameEntity>();

    public MoveEnemySystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.CurrentEnemy);
    }

    public void Execute()
    {
        moveEntities.Clear();

        foreach (var e in entities)
        {
            if (contexts.game.globals.nowEnemуTurn == true)
            {
                moveEntities.Add(e);
                runSpeed = contexts.game.globals.speed;
                targetPosition = e.enemyTarget.enemyTarget.position.value;
                myPosition = e.position.value;
                myRotation = e.rotation.rotation;
                // движение

                distance = targetPosition - myPosition;
                if (distance.magnitude < 0.00001f) 
                {
                    e.isEnemyAttack = true;       
                    contexts.game.globals.nowEnemуTurn = false;
                    break;
                }

                direction = distance.normalized;
                e.rotation.rotation = Quaternion.LookRotation(direction);

                targetPosition -= direction * distanceFromTarget;
                distance = (targetPosition - myPosition);

                step = direction * runSpeed; //* Time.deltaTime;    почему так БЫСТРО?
                if (step.magnitude < distance.magnitude) 
                {
                    myPosition += step;
                    //e.position.value = myPosition;
                    break;
                    //
                    //e.enemyTarget.enemyTarget.position.value = targetPosition;
                }
        
                myPosition = targetPosition;
               // e.position.value = myPosition;
                e.isEnemyAttack = true;       
                contexts.game.globals.nowEnemуTurn = false;
            }
        }

        foreach (var ee in moveEntities)
        {
            ee.position.value = myPosition;
            ee.isNeedMove = true;
        }
    }
}
