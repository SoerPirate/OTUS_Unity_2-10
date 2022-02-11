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

    public float speed;

    void Awake()
    {
        var context = Contexts.sharedInstance;

        systems = new Systems();
/*
        systems.Add(new DeathSystem(context));

        systems.Add(new PrefabInstantiateSystem(context));
        systems.Add(new TransformApplySystem(context));

        systems.Add(new FillPlayersListInGameControllerSystem(context));
        systems.Add(new FillEnemiesListInGameControllerSystem(context));

        systems.Add(new MarkEnemySystem(context));
        systems.Add(new MarkCurrentPlayerSystem(context));

        systems.Add(new NextPlayerSystem(context));
        systems.Add(new NextEnemySystem(context));

        systems.Add(new NextTargetSystem(context));
        systems.Add(new NextTargetNoButtonSystem(context));
        systems.Add(new PlayerMoveToEnemySystem(context));
        systems.Add(new PlayerAttackSystem(context));
        systems.Add(new PlayerMoveToStartPositionSystem(context));

        systems.Add(new EnemyNextTargetSystem(context));
        systems.Add(new EnemyMoveToPlayerSystem(context));
        systems.Add(new EnemyAttackSystem(context));
        systems.Add(new EnemyMoveToStartPositionSystem(context));

        systems.Add(new ViewDestroySystem(context));
*/
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
