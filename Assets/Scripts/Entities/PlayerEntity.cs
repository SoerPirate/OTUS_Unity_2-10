using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : AbstractEntity
{
    public GameObject prefab;
    public float health, speed;
    
    protected override void Start()
    {
        base.Start();
        entity.isPlayer = true;
        entity.AddPrefab(prefab);
        entity.AddHealth(health);
        entity.AddSpeed(speed);
     
    }
}
