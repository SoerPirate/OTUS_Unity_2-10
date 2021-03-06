using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PlayerAttackSystem : IExecuteSystem
{
    Animator animator;
    IGroup<GameEntity> entities;
    List<GameEntity> _entities = new List<GameEntity>();

    public PlayerAttackSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.ICurrentPlayer, 
        GameMatcher.HitTarget, GameMatcher.Attack, 
        GameMatcher.IAlive)); 
    }

    public void Execute()
    {
        _entities.Clear();

        foreach (var e in entities) 
        {
            _entities.Add(e);
        }

        foreach (var e in _entities) 
        {
            animator = e.view.gameObject.GetComponentInChildren<Animator>();
            animator.SetTrigger("Shoot");

            e.isAttack = false;

            e.hitTarget.hitTarget.health.value -= 1.0f;

            if (e.hitTarget.hitTarget.health.value <= 0.0f)
            {
                e.myGameController.gameController.GetComponent<GameController>().NextTargetNoButton();
                e.myGameController.gameController.GetComponent<GameController>().EnemyNextEnemyInPlayersTurn();
            }
        }
    }
}