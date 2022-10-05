using Common;
using Enemies;
using UnityEngine;

namespace Buildings
{
    public class Building : MonoBehaviour
    {
        public float health = 1f;
        public float touchDamageCooldown = 0.1f;
        public float touchDamage = 0.1f;
        
        private float _currentTime;
        
        public HealthBar healthBar;
        
        // Timer for cooldown.
        private void Start()
        {
            _currentTime = touchDamageCooldown;
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
        }

        public void OnCollisionStay2D(Collision2D col)
        {
            if (_currentTime <= 0f && col.gameObject.TryGetComponent (out Enemy.Enemy enemy))
            {
                enemy.TakeDamage(touchDamage);
                _currentTime = touchDamageCooldown;
            }
        }
        
        public void TakeDamage(float enemyDamage)
        {
            health -= enemyDamage;
            healthBar.HealthUpdate(health);
            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}