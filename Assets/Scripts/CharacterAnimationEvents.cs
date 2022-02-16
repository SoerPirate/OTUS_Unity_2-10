using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CharacterAnimationEvents : MonoBehaviour
{
    public bool shootEnd = false;
    public bool attackEnd = false;

    void Start()
    {

    }

    void ShootEnd()
    {
        shootEnd = true;
    }

    void AttackEnd()
    {
        attackEnd = true;
    }

    void PunchEnd()
    {

    }

    void DoDamage()
    {

    }
}
