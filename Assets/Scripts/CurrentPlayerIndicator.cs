using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerIndicator : MonoBehaviour
{
    void Start()
    {
        GetComponentInParent<EntitasEntity>().currentIndicator = gameObject;
        gameObject.SetActive(false);
    }
}
