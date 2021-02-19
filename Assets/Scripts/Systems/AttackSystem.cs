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
        return entity.isAttack && !entity.hasMoveTarget;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities) {
            e.isDebug = true;

            animator = e.view.gameObject.GetComponentInChildren<Animator>();
            animator.SetTrigger("Shoot");

            e.isAttack = false;
            /*
            var obj = GameObject.Instantiate(e.prefab.prefab);  //создаем объект согласно префабу лежащему в ентити
            if (obj.TryGetComponent<EntitasEntity>(out var ee))
                ee.entity = e;
            else
                obj.AddComponent<EntitasEntity>().entity = e;   //на объект вешаем скрипт (хранилище) для ентити которая его родила
            e.AddView(obj);     
            */                                //на ентити вешаем компонент, значит ентити родила объект (храним его) 
        }
    }
}