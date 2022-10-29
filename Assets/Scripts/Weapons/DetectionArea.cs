using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class DetectionArea : MonoBehaviour
{
    public UnityEvent<Enemy> onEnemyDetected;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Enemy enemy))
        {
            DetectEnemy(enemy);
        }
    }

    private void DetectEnemy(Enemy enemy)
    {
        onEnemyDetected.Invoke(enemy);
    }
}
