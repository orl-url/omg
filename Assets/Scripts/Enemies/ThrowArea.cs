using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowArea : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    private void Start()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out EnemyDamageableArea enemy))
        {
            Debug.Log("FixedJointAddedBefore");

            var enemyGoblin = enemy.GetComponentInParent<Enemy>();
            var fixedJoint = enemyGoblin.AddComponent<FixedJoint2D>();
            fixedJoint.connectedBody = _rb;

            var transformPosition = col.transform.position;
            transformPosition.y = transform.position.y + 2;
            col.transform.position = transformPosition;
            Debug.Log("FixedJointAdded");
        }
    }
}
