using Common;
using UnityEngine;

namespace Buildings
{
    public class Interaction : MonoBehaviour
    {
        public float buiHealth = 1f;
        public float damageCooldown = 0.1f;
        public float damage = 0.1f;
        private float _currentTime;
        
        
        public HealthBar healthBar;
        
        // Timer for cooldown.
        private void Start()
        {
            _currentTime = damageCooldown;
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
        }

        public void OnCollisionStay2D(Collision2D coll)
        {
            if (coll.gameObject.TryGetComponent (out Enemies.Enemy enemy) && _currentTime <= 0f)
            {
                enemy.TakeDamage(damage);
                _currentTime = damageCooldown;
            }
        }
        
        public void TakeDamage(float enemyDamage)
        {
            buiHealth -= enemyDamage;
            healthBar.HealthUpdate(buiHealth);
            if (buiHealth <= 0f)
            {
                BuiDestroy();
            }
        }
        
        private void BuiDestroy()
        {
            Destroy(gameObject); 
        }
    }
}