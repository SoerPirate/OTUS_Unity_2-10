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

    //public GameObject curentPlayer, curentEnemy; 

    public int enemyCount; 

    public float speed;

    public GameObject UIController;

    public GameEntity judgeGameLoop, curentEnemy;

    //public string debug;

    void Awake()
    {
        var context = Contexts.sharedInstance;

        judgeGameLoop = context.game.CreateEntity();
        judgeGameLoop.AddJudgeGameLoop(enemyCount);
        judgeGameLoop.isPlayerTurn = true;

        systems = new Systems();
        systems.Add(new DeathSystem(context));
        systems.Add(new PrefabInstantiateSystem(context));
        //systems.Add(new PlayerInputSystem(context));
        //systems.Add(new ShotCollisionSystem(context));
        //systems.Add(new PlayerCollisionSystem(context));
        systems.Add(new TransformApplySystem(context));
        systems.Add(new FillPlayersListInGameControllerSystem(context));
        systems.Add(new FillEnemiesListInGameControllerSystem(context));
        systems.Add(new NextTargetSystem(context));
        systems.Add(new MoveToSystem(context));
        systems.Add(new AttackSystem(context));
        //systems.Add(new ForwardMovementSystem(context));
        systems.Add(new ViewDestroySystem(context));
        //systems.Add(new MoveToSystem(context));       // создает компоненту дебаг на всех, тут не нужна, надо запустить по нажатию кнопки
        
        systems.Initialize();
    }

    void Start()
    {
        //buttonAttack.onClick.AddListener(PlayerAttack);                  вернуть на эту кнопку
        buttonAttack.onClick.AddListener(PlayerAttack); 
        buttonNextTarget.onClick.AddListener(NextTarget); 

        

        //playersGO[0].GetComponent<EntitasEntity>().entity.isITarget = true;
        
        //Utility.SetCanvasGroupEnabled(buttonPanel, false);
        //Utility.SetCanvasGroupEnabled(pausePanel, false);
        //StartCoroutine(GameLoop());
    }

    void OnDestroy()
    {
        systems.TearDown();
    }

    void Update()
    {
        systems.Execute();

        //playersGO.Clear();
        //enemiesGO.Clear();

        // можно сюда что-то писать?

        systems.Cleanup();
    }

    public void PlayerAttack()
    {
        if (judgeGameLoop.isPlayerTurn == true)
        {
            foreach (var enemy in enemiesGO)
            {
                curentEnemy = enemy.GetComponent<EntitasEntity>().entity;
            }

            foreach (var player in playersGO)
            {
                if (player.GetComponent<EntitasEntity>().entity.hasMoveTarget & player.GetComponent<EntitasEntity>().entity.hasHitTarget)
                {
                player.GetComponent<EntitasEntity>().entity.AddSpeed(speed);
                player.GetComponent<EntitasEntity>().entity.isAttack = true;
                }
                else
                {
                player.GetComponent<EntitasEntity>().entity.AddHitTarget(curentEnemy.position.value, curentEnemy); 
                player.GetComponent<EntitasEntity>().entity.AddMoveTarget(curentEnemy.position.value);
                player.GetComponent<EntitasEntity>().entity.AddSpeed(speed);
                player.GetComponent<EntitasEntity>().entity.isAttack = true;
                }
            }

            judgeGameLoop.isPlayerTurn = false;
        }
    }

    public void NextTarget()
    {
        //правильней создавать ентити-событие "следующий ход" и системами его ловить. а не хранить список игроков и обращаться к каждому
        
        if (judgeGameLoop.isPlayerTurn == true)
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
        //playersGO[0].GetComponent<EntitasEntity>().entity.Speed(speed);
        //playersGO[0].GetComponent<EntitasEntity>().entity.MoveTarget(speed);
        //playersGO[0].GetComponent<EntitasEntity>().entity.HitTarget(speed);

        //добавить нексттаргет, в нем сохраняется цель в переменную, переменная пробрасывается в хиттаргет, ее позиция в мувтаргет 
    }
}
