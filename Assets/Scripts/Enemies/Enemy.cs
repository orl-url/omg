using System;
using Common;
using Interfaces;
using UnityEngine;
using static EnemiesStats;


namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public static Action<Enemy> onDied;

        private float _health, _damage, _attackCooldown, _coinsForDeath, _currentTime;

        public EnemyType enemyType;
        public GameObject coin;
        public HealthBar healthBar;


        private void Init(AnyGoblin anyGoblin)
        {
            AnyGoblin.allEnemies.Add(this);
            GetComponent<Controller>().Init(anyGoblin);

            healthBar.maxHealth = anyGoblin.health;
            
            _health = anyGoblin.health;
            _damage = anyGoblin.damage;
            _attackCooldown = anyGoblin.attackCooldown;
            _coinsForDeath = anyGoblin.coinsForDeath;
        }
        
        
        // Timer for cooldown.
        private void Start()
        {
            _currentTime = _attackCooldown;
            
            switch (enemyType)
            {
                case EnemyType.LittleGoblin:
                    this.Init(AnyGoblin.LittleGoblin);
                    break;
                case EnemyType.BigGoblin:
                    this.Init(AnyGoblin.BossGoblin);
                    break;
            }
        }
        
        private void Update()
        {
            _currentTime -= Time.deltaTime;
        }


        // Damage the castle or some building.

        public void OnCollisionStay2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent (out IDamageable damageable) && _currentTime <= 0f)
            {
                damageable.TakeDamage(_damage);
                
                _currentTime = _attackCooldown;
            }
        }

        // Damage from castle or some building.
        public void TakeDamage(float damage)
        {
            
            _health -= damage;
            healthBar.HealthUpdate(_health);
            if (_health <= 0f)
            {
                Die();
                Destroy(gameObject);
                AnyGoblin.allEnemies.Remove(this);
                DropCoin();
            }
        }

        private void Die()
        {
            onDied?.Invoke(this);
            Destroy(gameObject);
            AnyGoblin.allEnemies.Remove(this);
            DropCoin();
        }

        private void DropCoin()
       {
           for (int x = 1; x <= this._coinsForDeath; x++)
           {
               Instantiate(coin, transform.position, Quaternion.identity);
           }
       }
    }
    

    public enum EnemyType
    {
        LittleGoblin,
        BigGoblin,
    }
}