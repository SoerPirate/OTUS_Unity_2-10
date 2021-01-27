using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // could be also: Contexts.sharedInstance.game.CreateEntity();
        GetComponent<EntitasEntity>().entity.isDetectedCollision = true;
    }
}
