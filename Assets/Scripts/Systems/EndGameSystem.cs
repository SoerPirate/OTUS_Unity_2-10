using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EndGameSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    bool endGame = false;
    Contexts contexts;

    public EndGameSystem(Contexts contexts)
    {
        this.contexts = contexts;

        entities = contexts.game.GetGroup(GameMatcher.Globals);
    }

    public void Execute()
    {
        foreach (var e in entities) 
        {
            if (endGame == false)
            {
                if (contexts.game.globals.enemyCount == 0)
                {
                    Debug.Log("Player Win");
                    endGame = true;
                }

                if (contexts.game.globals.playerCount == 0)
                {
                    Debug.Log("You lose");
                    endGame = true;
                }
            }
        }    
    }
}
