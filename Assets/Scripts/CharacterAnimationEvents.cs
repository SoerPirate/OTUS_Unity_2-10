using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CharacterAnimationEvents : MonoBehaviour
{
    public EntitasEntity EntitasEntity;

    public float speed;

    void Start()
    {
        //character = GetComponentInParent<Character>();
    }

    void ShootEnd()
    {
        EntitasEntity = GetComponentInParent<EntitasEntity>();

        //EntitasEntity.entity.isAttack = false;

        speed = EntitasEntity.gameController.GetComponent<GameController>().speed;
        EntitasEntity.entity.AddSpeed(speed);

        //Debug.Log("Пошел обратно");    
    }

    void AttackEnd()
    {
        //character.SetState(Character.State.RunningFromEnemy);
    }

    void PunchEnd()
    {
        //character.SetState(Character.State.RunningFromEnemy);
    }

    void DoDamage()
    {
        //Character targetCharacter = character.target.GetComponent<Character>();
        //targetCharacter.DoDamage();
    }
}
