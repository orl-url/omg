using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using Interfaces;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class DetectionArea : MonoBehaviour
{
    public UnityEvent<Enemy> onEnemyDetected;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out IEnemyDamageable enemy))
        {
            var enemyCor = col.gameObject.GetComponentInParent<Enemy>();
            DetectEnemy(enemyCor);
        }
    }

    private void DetectEnemy(Enemy enemy)
    {
        onEnemyDetected.Invoke(enemy);
    }
}
