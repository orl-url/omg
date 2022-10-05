using UnityEngine;
using Common;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public float health = 1f;
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
        public void OnCollisionStay2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent (out Buildings.Interaction building) && _currentTime <= 0f)
            {
                building.TakeDamage(damage);
                _currentTime = attackCooldown;
            }
        }
        
        // Damage from castle or some building.
       public void TakeDamage(float Damage)
       {
           health -= Damage;
           healthBar.HealthUpdate(health);
           if (health <= 0f)
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