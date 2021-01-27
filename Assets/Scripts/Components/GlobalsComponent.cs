using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public class GlobalsComponent : IComponent
{
    public GameObject shotPrefab;
}
