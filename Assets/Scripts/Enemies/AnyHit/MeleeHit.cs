using System;
using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class MeleeHit : MonoBehaviour
    {
        private  float _meleeDamage;
        private float _meleeAttackCooldown;
        private float _meleeTimer;
        
        
        private void Start()
        {
            _meleeTimer = _meleeAttackCooldown;
        }
        
        public void Init(EnemiesStats.AnyGoblin anyGoblin)
        {
            _meleeDamage = anyGoblin.meleeDamage;
            _meleeAttackCooldown = anyGoblin.meleeAttackCooldown;
        }
        
        
        private void Update()
        {
            if (_meleeTimer < 0f)
                return;
        
            _meleeTimer -= Time.deltaTime;
        }

        private void OnCollisionStay2D(Collision2D col)
        {
            if (_meleeTimer > 0f) 
                return;
            
            if (col.collider.TryGetComponent (out IBuiDamageable buiDamageable))
            {
                buiDamageable.TakeDamage(_meleeDamage);
            
                _meleeTimer = _meleeAttackCooldown;
            }
        }
    }
}

