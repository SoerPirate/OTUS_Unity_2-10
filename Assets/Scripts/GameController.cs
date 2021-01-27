using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    public GameObject shotPrefab;
    Systems systems;

    void Awake()
    {
        var context = Contexts.sharedInstance;

        context.game.SetGlobals(shotPrefab);

        systems = new Systems();
        systems.Add(new DeathSystem(context));
        systems.Add(new PrefabInstantiateSystem(context));
        systems.Add(new PlayerInputSystem(context));
        systems.Add(new ForwardMovementSystem(context));
        systems.Add(new ShotCollisionSystem(context));
        systems.Add(new PlayerCollisionSystem(context));
        systems.Add(new TransformApplySystem(context));
        systems.Add(new ViewDestroySystem(context));
        systems.Initialize();
    }

    void OnDestroy()
    {
        systems.TearDown();
    }

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
