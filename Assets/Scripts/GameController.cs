using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    Systems systems;

    void Awake()
    {
        var context = Contexts.sharedInstance;

        systems = new Systems();
        //systems.Add(new DeathSystem(context));
        systems.Add(new PrefabInstantiateSystem(context));
        //systems.Add(new PlayerInputSystem(context));
        //systems.Add(new ForwardMovementSystem(context));
        //systems.Add(new ShotCollisionSystem(context));
        //systems.Add(new PlayerCollisionSystem(context));
        systems.Add(new TransformApplySystem(context));
        systems.Add(new ViewDestroySystem(context));
        //systems.Add(new MoveToSystem(context));       // создает компоненту дебаг на всех, тут не нужна, надо запустить по нажатию кнопки
        
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
