using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using Interfaces;
using UnityEditor.Timeline;
using UnityEngine;

public class ArcherHit : RangeHit
{
    [SerializeField] private ArrowsSpawner arrowsSpawner;
    private Rigidbody2D _rb;

    private float _timer;
    private float _cooldown = 0.5f;
    
    private void Start()
    {
        _rb = GetComponentInParent<Rigidbody2D>();

        _timer = _cooldown;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_timer <= 0 && other.gameObject.TryGetComponent(out IBuiDamageable buiDamageable))
        {
            var target = other.transform.position;
            _rb.bodyType = RigidbodyType2D.Kinematic;
            arrowsSpawner.Spawn(target, EnemiesStats.AnyGoblin.ArcherGoblin.rangeDamage);
            _timer = _cooldown;
        }
    }
}
