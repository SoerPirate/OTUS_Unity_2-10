using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class AttackSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;

    Animator animator;

    public AttackSystem(Contexts contexts)
        : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return new Collector<GameEntity>(
            new [] {
                context.GetGroup(GameMatcher.MoveTarget)
            }, new [] {
                GroupEvent.Removed
            }
        );
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isAttack && entity.isIAlive; //!entity.hasMoveTarget;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities) 
        {
            animator = e.view.gameObject.GetComponentInChildren<Animator>();
            animator.SetTrigger("Shoot");

            e.hitTarget.hitTarget.health.value -= 1.0f;

            e.isAttack = false;

            e.AddMoveTarget(e.startPosition.startPosition);
            e.AddSpeed(2.0f); 

            

            e.isDebug = false;
            e.isDebug2 = false;
        }

        //foreach (var e in entities)
        //{
        //    e.isDebug2 = true;    
        //}
    }
}