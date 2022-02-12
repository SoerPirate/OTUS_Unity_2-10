using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;
using TMPro;
    
public class GameController : MonoBehaviour
{
    Systems systems;

    public Button buttonAttack, buttonNextTarget;

    public float _speed;

    void Awake()
    {
        var context = Contexts.sharedInstance;

        context.game.SetGlobals(_speed, null, null, null, null, false, false); 

        //var s = context.game.globals.speed * 3;

        systems = new Systems();

        systems.Add(new DeathSystem(context));
        systems.Add(new PrefabInstantiateSystem(context));

        systems.Add(new FindCurrentPlayerSystem(context));

        systems.Add(new TransformApplySystem(context));

        //systems.Add(new ViewDestroySystem(context));

        systems.Initialize();
    }

    void Start()
    {
        buttonAttack.onClick.AddListener(PlayerAttack); 
        buttonNextTarget.onClick.AddListener(NextTarget); 
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

    public void PlayerAttack()
    {

    }

    public void NextTarget()
    {

    }
}
