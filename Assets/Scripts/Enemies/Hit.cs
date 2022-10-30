using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class Hit : MonoBehaviour
    {
        internal float _meleeDamage, _meleeAttackCooldown;
        
        internal float _rangeDamage, _rangeAttackCooldown;


        internal float _meleeTimer = 1f, _rangeTimer = 1f;

        public void Init(EnemiesStats.AnyGoblin anyGoblin)
        {
            _meleeDamage = anyGoblin.meleeDamage;
            _meleeAttackCooldown = anyGoblin.meleeAttackCooldown;

            _rangeDamage = anyGoblin.rangeDamage;
            _rangeAttackCooldown = anyGoblin.rangeAttackCooldown;

            // Debug.Log("melee" + _meleeDamage);
            // Debug.Log("range" + _rangeDamage);
            
            
        }
    
        private void Start()
        {
            _meleeTimer = _meleeAttackCooldown;
            _rangeTimer = _rangeAttackCooldown;
        }
    
        private void Update()
        {
            // if (_meleeTimer < 0f)
                // return;
        
            _meleeTimer -= Time.deltaTime;
            _rangeTimer -= Time.deltaTime;
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
