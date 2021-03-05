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

    public GameEntity judgeGameLoop, curentPlayerTarget, curentEnemyTarget, curentPlayerTargetF; 

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

        systems.Add(new NextPlayerSystem(context));
        systems.Add(new NextEnemySystem(context));

        systems.Add(new NextTargetSystem(context));
        systems.Add(new PlayerMoveToEnemySystem(context));
        systems.Add(new PlayerAttackSystem(context));
        systems.Add(new PlayerMoveToStartPositionSystem(context));

        systems.Add(new EnemyNextTargetSystem(context));
        systems.Add(new EnemyMoveToPlayerSystem(context));
        systems.Add(new EnemyAttackSystem(context));
        systems.Add(new EnemyMoveToStartPositionSystem(context));

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
            curentPlayerTarget = player.GetComponent<EntitasEntity>().entity;
            curentPlayerTarget.isICurrentPlayer = true;
            curentPlayerTargetF = curentPlayerTarget;
            currentPlayerCount++;
            }
        }

        foreach (var enemy in enemiesGO)
        {
            if (currentEnemyCount==1)
            {
            curentEnemyTarget = enemy.GetComponent<EntitasEntity>().entity;
            curentEnemyTarget.isICurrentEnemy = true;     // включать систему маркировки цели 
            currentEnemyCount++;                                            // отдельной системой ставить марку по хиттаргету?
            }
        }
        }

        systems.Cleanup();
    }

    public void PlayerAttack()
    {
        if (playerTurn == false & enemyTurn == false)
        {
            if (curentPlayerTargetF.isICurrentPlayer == false)
            {
                NextPlayer();
                Debug.Log("NextPlayer");
            }

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
                    player.GetComponent<EntitasEntity>().entity.ReplaceMoveTarget(curentEnemyTarget.position.value);
                                                                //Add ?
                    player.GetComponent<EntitasEntity>().entity.ReplaceSpeed(speed);
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

    public void NextPlayer()   
    {
        foreach (var player in playersGO)
        {
            player.GetComponent<EntitasEntity>().entity.isFindNextPlayer = true;
        }

        judgeGameLoop.isFindNextPlayer = true;
        //judgeGameLoop.judgeGameLoop.playerCount++;
    }
            
    public void EnemyTurn()
    {
        if (playerTurn == false & enemyTurn == true)
        {
            Debug.Log("EnemyTurn");  

            foreach (var enemy in enemiesGO)
            {
                if (!enemy.GetComponent<EntitasEntity>().entity.hasHitTarget)
                {
                    enemy.GetComponent<EntitasEntity>().entity.AddHitTarget(curentPlayerTarget.position.value, curentPlayerTarget); 
                    enemy.GetComponent<EntitasEntity>().entity.AddMoveTarget(curentPlayerTarget.position.value);
                    enemy.GetComponent<EntitasEntity>().entity.AddSpeed(speed);
                }
                else
                {
                    curentPlayerTarget = enemy.GetComponent<EntitasEntity>().entity.hitTarget.hitTarget; 
                    enemy.GetComponent<EntitasEntity>().entity.ReplaceMoveTarget(curentPlayerTarget.position.value);

                    enemy.GetComponent<EntitasEntity>().entity.ReplaceSpeed(speed);
                }
            }
        
        }
    }

    public void EnemyNextTarget()  
    {
        foreach (var player in playersGO)
            {
                player.GetComponent<EntitasEntity>().entity.isEnemyNextTarget = true;
            }
        
            foreach (var enemy in enemiesGO)
            {
                enemy.GetComponent<EntitasEntity>().entity.isEnemyNextTarget = true;
            }

            judgeGameLoop.isEnemyNextTarget = true;
    }

    public void EnemyNextEnemy()    
    {
        Debug.Log("EnemyNextEnemy");

        foreach (var enemy in enemiesGO)
        {
            enemy.GetComponent<EntitasEntity>().entity.isFindNextEnemy = true;
        }

        judgeGameLoop.isFindNextEnemy = true;
        //judgeGameLoop.judgeGameLoop.playerCount++;
    }
}
