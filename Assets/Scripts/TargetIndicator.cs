using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void SetActiveTrue()
    {
        gameObject.SetActive(true);
    }
    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
