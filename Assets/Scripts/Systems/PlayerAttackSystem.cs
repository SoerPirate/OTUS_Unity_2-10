using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PlayerAttackSystem : IExecuteSystem
{
    // можно было сделать вместо PlayTargetComp + EnemyTargCom универсальный TargetComp, 
    // а в этой системе сделать Switch + Case оружия
    // и if nowEnemуTurn или nowPlayerTurn
    IGroup<GameEntity> entities;
    Contexts contexts;
    EntitasEntity entitasEntity;
    bool animationNow = false;

    public PlayerAttackSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.CurrentPlayer);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            //if ((contexts.game.globals.attackButton == true) & (e.playerTarget.playerTarget.hasHealth))
            if (contexts.game.globals.attackButton == true) 
            {
                //contexts.game.globals.attackButton = false;
                if (animationNow == false)
                {
                    entitasEntity = e.view.gameObject.GetComponent<EntitasEntity>();
                    entitasEntity.animator.SetTrigger("Shoot");
                    animationNow = true;
                }
                
                if (entitasEntity.caracterAnimationEvents.shootEnd == true)
                {
                    if (e.playerTarget.playerTarget.hasHealth)      // ???
                    {
                        e.playerTarget.playerTarget.health.value -=1;  
                        entitasEntity.caracterAnimationEvents.shootEnd = false;
                        contexts.game.globals.attackButton = false;
                        animationNow = false;
                        contexts.game.globals.nowEnemуTurn = true;
                    }
                    
                }
            }
        }
    }
}
