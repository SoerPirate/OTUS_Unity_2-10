using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class JudgeGameLoopComponent : IComponent
{
    public int enemyCount, playerCount;              // кто будет следующим, а не кто выбран сейчас
}
