using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PlayerAttackSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    Contexts contexts;
    EntitasEntity entitasEntity;

    public PlayerAttackSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.CurrentPlayer);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (contexts.game.globals.attackButton == true)
            {
                entitasEntity = e.view.gameObject.GetComponent<EntitasEntity>();
                entitasEntity.animator.SetTrigger("Shoot");
                e.playerTarget.playerTarget.health.value -=1;  
                contexts.game.globals.attackButton = false;
                contexts.game.globals.nowEnemуTurn = true;
            }
        }
    }
}
