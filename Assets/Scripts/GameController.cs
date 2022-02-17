using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
    
public class GameController : MonoBehaviour
{
    Systems systems;
    Contexts contexts;
    public Button buttonAttack, buttonNextTarget;
    public CanvasGroup playerMenu;
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
            0,                      // currentEnemyIndex
            true, true);          // changeDeadEnemy, changeDeadPlayer            

        systems = new Systems();

        systems.Add(new DeathSystem(contexts));
        systems.Add(new PrefabInstantiateSystem(contexts));

        systems.Add(new FindCurrentPlayerSystem(contexts));
        systems.Add(new FindCurrentEnemySystem(contexts));



        systems.Add(new ChangeDeadEnemySystem(contexts));
        systems.Add(new ChangeDeadPlayerSystem(contexts));

        systems.Add(new FillPlayerTargetSystem(contexts));
        systems.Add(new FillEnemyTargetSystem(contexts));

        systems.Add(new TargetIndicatorSystem(contexts));
        systems.Add(new PlayerTargIndFalseSystem(contexts));
        systems.Add(new EnemyTargIndFalseSystem(contexts));

        systems.Add(new MarkIndicatorSystem(contexts));
        systems.Add(new MarkIndicatorPLSystem(contexts));
        //systems.Add(new MarkEnemyOffSystem(contexts));
        //systems.Add(new MarkPlayerOffSystem(contexts));
        
        systems.Add(new NextTargetSystem(contexts));

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

/*
    void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(settingsScreen, screen == Screen.Settings);
        Utility.SetCanvasGroupEnabled(ChooseLevelScreen, screen == Screen.ChooseLevel);
    }

    public static void SetCanvasGroupEnabled(CanvasGroup group, bool enabled)
    {
        //group.alpha = (enabled ? 1.0f : 0.0f);
        group.GetComponent<AlphaAnimator>().targetAlpha = (enabled ? 1.0f : 0.0f);
        group.interactable = enabled;
        group.blocksRaycasts = enabled;
    }
*/
}
