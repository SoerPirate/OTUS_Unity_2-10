using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    TextMesh textMesh;
    float health;
    float displayedHealth;

    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        health = GetComponentInParent<EntitasEntity>().entity.health.value;
        displayedHealth = health - 1.0f;
    }

    void Update()
    {
        float value = GetComponentInParent<EntitasEntity>().entity.health.value;
        if (!Mathf.Approximately(displayedHealth, value)) { // !=
            displayedHealth = value;
            textMesh.text = $"{value}";
        }
    }
}
