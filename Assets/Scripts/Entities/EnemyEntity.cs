using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : AbstractEntity
{
    public GameObject prefab, gameController;
    public float health, speed;
    //public Animator animator;

    protected override void Start()
    {
        base.Start();
        entity.isEnemy = true;
        entity.AddPrefab(prefab);
        entity.AddHealth(health); 
        //entity.AddSpeed(speed);
        entity.AddMyGameController(gameController);

        //animator = entity.prefab.prefab.GetComponentInChildren<Animator>();
        //entity.AddAnimator(animator);

        //entity.AddForwardMovement(speed);
    }
}
