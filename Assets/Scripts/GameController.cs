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

    public List<GameObject> playersGO = new List<GameObject>();

    public List<GameObject> enemiesGO = new List<GameObject>();

    private int currentEnemyCount = 1, currentPlayerCount = 1; 

    public float speed;

    public GameObject UIController;

    public GameEntity judgeGameLoop, iCurrentPlayer, curentEnemyTarget;

    public bool playerTurn = false, enemyTurn = false;


    void Awake()
    {
        var context = Contexts.sharedInstance;

        judgeGameLoop = context.game.CreateEntity();
        judgeGameLoop.AddJudgeGameLoop(currentEnemyCount, currentPlayerCount);

        systems = new Systems();

        systems.Add(new DeathSystem(context));

        systems.Add(new PrefabInstantiateSystem(context));
        systems.Add(new TransformApplySystem(context));

        systems.Add(new FillPlayersListInGameControllerSystem(context));
        systems.Add(new FillEnemiesListInGameControllerSystem(context));

        systems.Add(new NextTargetSystem(context));
        systems.Add(new PlayerMoveToEnemySystem(context));
        systems.Add(new PlayerAttackSystem(context));
        systems.Add(new PlayerMoveToStartPositionSystem(context));

        systems.Add(new ViewDestroySystem(context));

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

        if (currentPlayerCount==1 & currentEnemyCount==1)
        {
        foreach (var player in playersGO)
        {
            if (currentPlayerCount==1)
            {
            iCurrentPlayer = player.GetComponent<EntitasEntity>().entity;
            player.GetComponent<EntitasEntity>().entity.isICurrentPlayer = true;
            currentPlayerCount++;
            }
        }

        foreach (var enemy in enemiesGO)
        {
            if (currentEnemyCount==1)
            {
            curentEnemyTarget = enemy.GetComponent<EntitasEntity>().entity;
            enemy.GetComponent<EntitasEntity>().entity.isITarget = true;             // включать систему маркировки цели
            currentEnemyCount++;
            }
        }
        }

        systems.Cleanup();
    }

    public void PlayerAttack()
    {
        if (playerTurn == false & enemyTurn == false)
        {
            foreach (var player in playersGO)
            {
                if (!player.GetComponent<EntitasEntity>().entity.hasHitTarget)
                {
                    player.GetComponent<EntitasEntity>().entity.AddHitTarget(curentEnemyTarget.position.value, curentEnemyTarget); 
                    player.GetComponent<EntitasEntity>().entity.AddMoveTarget(curentEnemyTarget.position.value);
                    player.GetComponent<EntitasEntity>().entity.AddSpeed(speed);
                }
                else
                {
                    curentEnemyTarget = player.GetComponent<EntitasEntity>().entity.hitTarget.hitTarget;
                    player.GetComponent<EntitasEntity>().entity.AddMoveTarget(curentEnemyTarget.position.value);

                    player.GetComponent<EntitasEntity>().entity.AddSpeed(speed);
                }
            }

            playerTurn = true;
        }
    }

    public void NextTarget()
    {
        if (playerTurn == false & enemyTurn == false)
        {
            foreach (var player in playersGO)
            {
                player.GetComponent<EntitasEntity>().entity.isNextTarget = true;
            }
        
            foreach (var enemy in enemiesGO)
            {
                enemy.GetComponent<EntitasEntity>().entity.isNextTarget = true;
            }

            judgeGameLoop.isNextTarget = true;
        }
    }
}
