using System;
using Common;
using UnityEngine;
using static EnemiesStats;


namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public static Action<Enemy> onDied;

        private float _health,_coinsForDeath;

        public GameObject coin;
        public HealthBar healthBar;
        
        
        protected void Init(AnyGoblin anyGoblin)
        {
            _health = anyGoblin.health;
            _coinsForDeath = anyGoblin.coinsForDeath;

            MeleeHitInit(anyGoblin);
            RangeHitInit(anyGoblin);
            ControllerInit(anyGoblin);
            SetMaxHpInHealthBar(anyGoblin);
            AddToStaticListOfEnemies();
        }

        
        private void MeleeHitInit(AnyGoblin anyGoblin)
        {
            var meleeHit = GetComponentInChildren<MeleeHit>();
            meleeHit.Init(anyGoblin);
        }
        
        private void RangeHitInit(AnyGoblin anyGoblin)
        {
            if ( gameObject.TryGetComponent(out RangeHit rangeHit))
                rangeHit.Init(anyGoblin);
        }
        
        private void ControllerInit(AnyGoblin anyGoblin)
        {
            var controller = GetComponentInChildren<Controller>();
            controller.Init(anyGoblin);
        }
        
        private void AddToStaticListOfEnemies()
        {  
            AnyGoblin.allEnemies.Add(this);
        }
        
        private void SetMaxHpInHealthBar(AnyGoblin anyGoblin)
        {
            healthBar.maxHealth = anyGoblin.health;
        }
        
        
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
           for (int x = 1; x <= _coinsForDeath; x++)
           {
               Instantiate(coin, transform.position, Quaternion.identity);
           }
       }
    }
}