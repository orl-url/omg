using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class Hit : MonoBehaviour
    {
        internal float _meleeDamage, _meleeAttackCooldown;
        
        internal float _rangeDamage, _rangeAttackCooldown;
    
        public void Init(EnemiesStats.AnyGoblin anyGoblin)
        {
            _meleeDamage = anyGoblin.meleeDamage;
            _meleeAttackCooldown = anyGoblin.meleeAttackCooldown;
    
            _rangeDamage = anyGoblin.rangeDamage;
            _rangeAttackCooldown = anyGoblin.rangeAttackCooldown;
            
        }
        
        
    
        // private void OnCollisionStay2D(Collision2D col)
        // {
        //     if (col.gameObject.TryGetComponent (out IBuiDamageable damageable) && _meleeTimer <= 0f)
        //     {
        //         damageable.TakeDamage(_meleeDamage);
        //     
        //         // _meleeTimer = _meleeAttackCooldown;
        //     }
        // }
    }
}
