using System;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    public class RangeHit : Hit
    {
        private Collider2D _collider2D;
        private bool _isShieldDestroyed;
        public Shield shield;

        private void Awake()
        {
            Init(EnemiesStats.AnyGoblin.GoblinDefender);
        }

        private void FixedUpdate()
        {
            _isShieldDestroyed = shield.isShieldDestroyed;
        }

        private void RangeAttack(IBuiDamageable damageable)
        {
            if (_isShieldDestroyed)
                return;
            
            shield.gameObject.SetActive(false);
            
            
            
            damageable.TakeDamage(_rangeDamage);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out IBuiDamageable damageable))
            {
                RangeAttack(damageable);
                gameObject.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
