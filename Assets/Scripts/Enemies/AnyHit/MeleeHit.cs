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
        
        public new void Init(EnemiesStats.AnyGoblin anyGoblin)
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
            if (col.gameObject.TryGetComponent (out IBuiDamageable damageable) && _meleeTimer <= 0f)
            {
                damageable.TakeDamage(_meleeDamage);
            
                _meleeTimer = _meleeAttackCooldown;
            }
        }
    }
}

