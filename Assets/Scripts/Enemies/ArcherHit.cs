using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using Interfaces;
using UnityEngine;

public class ArcherHit : RangeHit
{
    private Rigidbody2D _rb;
    
    
    private void Start()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IBuiDamageable buiDamageable))
        {
            _rb.bodyType = RigidbodyType2D.Kinematic;
            
        }
    }
}
