using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class AttackEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    List<GameEntity> endAttack = new List<GameEntity>();
    EntitasEntity entitasEntity;
    bool animationNow = false;

    public AttackEnemySystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.EnemyAttack);
    }

    public void Execute()
    {
        endAttack.Clear();

        foreach (var e in entities)
        {
            if (animationNow == false)
            {
                entitasEntity = e.view.gameObject.GetComponent<EntitasEntity>();
                entitasEntity.animator.SetTrigger("MeleeAttack");
                animationNow = true;
            }

            if (entitasEntity.caracterAnimationEvents.attackEnd == true)
            {
                e.enemyTarget.enemyTarget.health.value -=1;  
                animationNow = false;
                entitasEntity.caracterAnimationEvents.attackEnd = false;
                endAttack.Add(e);
                contexts.game.globals.nowPlayerTurn = true;
            }
        }

        foreach (var ee in endAttack)
        {
            ee.isEnemyAttack = false;
            
        }
    }
}
