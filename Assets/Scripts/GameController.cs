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
        var contexts = Contexts.sharedInstance;

        contexts.game.SetGlobals(_speed, null, null, null, null, false, false); 

        //var s = contexts.game.globals.speed * 3;

        systems = new Systems();

        systems.Add(new DeathSystem(contexts));
        systems.Add(new PrefabInstantiateSystem(contexts));

        systems.Add(new FindCurrentPlayerSystem(contexts));
        systems.Add(new FindCurrentEnemySystem(contexts));

        systems.Add(new FillPlayerTargetSystem(contexts));
        systems.Add(new FillEnemyTargetSystem(contexts));

        systems.Add(new TransformApplySystem(contexts));

        //systems.Add(new ViewDestroySystem(contexts));

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
        //contexts.game.globals.attackButton = true;
    }

    public void NextTarget()
    {
        //contexts.game.globals.nextTargetButton = true;  ?? нужно ставить needFindPlayerTarget = true;
    }
}
