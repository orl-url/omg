using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class ShieldDamageableArea : MonoBehaviour, IEnemyDamageable
    {
        [SerializeField] 
        private GameObject someShield;

        public void TakeDamage(float damage)
        {
            someShield.GetComponent<Shield>().TakeDamage(damage);
        }
    }
}
