using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class AttackEnemySystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    List<Entity> endAttack = new List<Entity>();

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
            e.enemyTarget.enemyTarget.health.value -=1;  
            endAttack.Add(e);
        }

        foreach (var e in endAttack)
        {
            //e.isEnemyAttack = false;
        }
    }
}
