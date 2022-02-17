using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveBackEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    Vector3 distance, direction, step, targetPosition, myPosition;
    float runSpeed;
    Quaternion myRotation;
    List<GameEntity> moveEntities = new List<GameEntity>();
    List<GameEntity> endMoveEntities = new List<GameEntity>();
    EntitasEntity entitasEntity;
    bool animationNow = false;

    public MoveBackEnemySystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.MoveBack);
    }

    public void Execute()
    {
        moveEntities.Clear();
        endMoveEntities.Clear();

        foreach (var e in entities)
        {
            
            moveEntities.Add(e);
            runSpeed = contexts.game.globals.speed;
            targetPosition = e.startPosition.startPosition;
            myPosition = e.position.value;
            myRotation = e.rotation.rotation;

            if (animationNow == false)
            {
                entitasEntity = e.view.gameObject.GetComponent<EntitasEntity>();
                entitasEntity.animator.SetFloat("Speed", runSpeed);
                animationNow = true;
            }
            
            // движение
            distance = targetPosition - myPosition;
            if (distance.magnitude < 0.00001f) 
            {
                endMoveEntities.Add(e);
                break;
            }

            direction = distance.normalized;
            e.rotation.rotation = Quaternion.LookRotation(direction);

            step = direction * runSpeed; 
            if (step.magnitude < distance.magnitude) 
            {
                myPosition += step;
                break;
            }

            myPosition = targetPosition;
            entitasEntity.animator.SetFloat("Speed", 0.0f);
            endMoveEntities.Add(e);       
        }

        foreach (var ee in moveEntities)
        {
            ee.position.value = myPosition;
            ee.isNeedMove = true;
        }

        foreach (var eee in endMoveEntities)
        {
            eee.rotation.rotation = eee.startRotation.startRotation;
            eee.isMoveBack = false;     
            animationNow = false;
            contexts.game.globals.nowPlayerTurn = true;
        }
    }
}
