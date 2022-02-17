using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public class GlobalsComponent : IComponent
{
    public float speed;
    public GameEntity currentPlayer;
    public GameEntity currentEnemy;
    public GameEntity playerTarget;
    public GameEntity enemyTarget;
    public bool nowPlayerTurn = false;
    public bool nowEnemуTurn = false;
    public bool needFindCurrentPlayer = true;  
    public bool needFindCurrentEnemy = true;
    public bool needFillPlayerTarget = true;
    public bool needFillEnemyTarget = true;
    public bool nextTargetButton = false;
    public bool attackButton = false;
    public int currentEnemyIndex;
    public bool changeDeadEnemy = false;
    public bool changeDeadPlayer = false;
    public CanvasGroup playerMenu;
    public int enemyCount = 0, playerCount = 0;
}
