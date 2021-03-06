using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EntitasEntity : MonoBehaviour
{
    public GameEntity entity;

    public GameObject gameController, mark; 

    public void MarkOn()
    {
        mark.SetActive(true);
    }

    public void MarkOff()
    {
        mark.SetActive(false);
    }
}
