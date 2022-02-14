using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EntitasEntity : MonoBehaviour
{
    public GameEntity entity;
    public Animator animator;
    public CharacterAnimationEvents caracterAnimationEvents; 

    void Start() 
    {
        animator = GetComponentInChildren<Animator>();
        caracterAnimationEvents = GetComponentInChildren<CharacterAnimationEvents>();
    }
}
