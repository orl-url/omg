using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class EnemyDamageableArea : MonoBehaviour, IEnemyDamageable
    {
        [SerializeField] 
        private GameObject someEnemy;

        public void TakeDamage(float damage)
        {
            someEnemy.GetComponentInParent<Enemy>().TakeDamage(damage);
        }
    
    
    }
}
