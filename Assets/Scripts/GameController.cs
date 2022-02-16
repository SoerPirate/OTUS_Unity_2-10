using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;
using TMPro;
    
public class GameController : MonoBehaviour
{
    Systems systems;
    Contexts contexts;
    public Button buttonAttack, buttonNextTarget;
    public float _speed;

    void Awake()
    {
        var contexts = Contexts.sharedInstance;
        this.contexts = contexts;

        contexts.game.SetGlobals(
            _speed,                 // speed
            null, null, null, null, // currentPlayer, currentEnemy, playerTarget, enemyTarget
            true, false,            // nowPlayerTurn, nowEnemуTurn
            true, true, true, true, // needFindCurrentPlayer, needFindCurrentEnemy, needFillPlayerTarget, needFillEnemyTarget
            false, false,           // nextTargetButton, attackButton
            0);                     // currentEnemyIndex

        systems = new Systems();

        systems.Add(new DeathSystem(contexts));
        systems.Add(new PrefabInstantiateSystem(contexts));

        systems.Add(new FindCurrentPlayerSystem(contexts));
        systems.Add(new FindCurrentEnemySystem(contexts));

        systems.Add(new FillPlayerTargetSystem(contexts));
        systems.Add(new FillEnemyTargetSystem(contexts));

        systems.Add(new NextTargetSystem(contexts));

        systems.Add(new TargetIndicatorSystem(contexts));
        systems.Add(new PlayerTargIndFalseSystem(contexts));
        systems.Add(new EnemyTargIndFalseSystem(contexts));
        
        systems.Add(new PlayerAttackSystem(contexts));
        systems.Add(new MoveEnemySystem(contexts));
        systems.Add(new AttackEnemySystem(contexts));
        systems.Add(new MoveBackEnemySystem(contexts));

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
        if (contexts.game.globals.nowPlayerTurn == true)
        {
            contexts.game.globals.nowPlayerTurn = false;
            contexts.game.globals.attackButton = true;
        }
            
    }

    public void NextTarget()
    {
        if (contexts.game.globals.nowPlayerTurn == true)
            contexts.game.globals.nextTargetButton = true; 
    }
}
