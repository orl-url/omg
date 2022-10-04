using UnityEngine;
using Common;

namespace Enemies
{
    public class Interaction : MonoBehaviour
    {
        public float enemyHealth = 1f;
            public float damage = 0.25f;
        public float attackCooldown = 0.3f;
        private float _currentTime;
        public GameObject coin;
        
        
        public HealthBar healthBar;
        
        // Timer for cooldown.
        private void Start()
        {
            _currentTime = attackCooldown;
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
        }

        // Damage the castle or some building.
        public void OnCollisionStay2D(Collision2D coll)
        {
            if (coll.gameObject.TryGetComponent (out Buildings.Interaction building) && _currentTime <= 0f)
            {
                building.TakeDamage(damage);
                _currentTime = attackCooldown;
            }
        }
        
        // Damage from castle.
       public void TakeDamage(float castleDamage)
       {
           enemyHealth -= castleDamage;
           healthBar.HealthUpdate(enemyHealth);
           if (enemyHealth <= 0f)
           {
               KillEnemy();
           }
       }

       // ReSharper disable Unity.PerformanceAnalysis
       // Kill enemy and create coin.
       private void KillEnemy()
       {
           Destroy(gameObject);
           DropCoin();
       }

       private void DropCoin()
       {
           Instantiate(coin, transform.position, Quaternion.identity);
       }
       
    }
}