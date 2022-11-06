using System;
using Common;
using Unity.VisualScripting;
using UnityEngine;
using static EnemiesStats;


namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public static Action<Enemy> onDied;

        public EnemyType enemyType;
        
        private float _health,_coinsForDeath;
        public bool beUsedForThrow = false;

        public GameObject coin;
        public HealthBar healthBar;
        internal Controller controller;


        internal void Init(AnyGoblin anyGoblin)
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
            MeleeHit meleeHit;
            if (meleeHit = gameObject.GetComponentInChildren<MeleeHit>())
            {
                meleeHit.Init(anyGoblin);
            }
        }
        
        private void RangeHitInit(AnyGoblin anyGoblin)
        {
            RangeHit rangeHit;
            
            if (rangeHit = gameObject.GetComponentInChildren<RangeHit>())
            {
               rangeHit.Init(anyGoblin);
                // Debug.Log("rangeHitInit - did ");
            }
        }
        
        private void ControllerInit(AnyGoblin anyGoblin)
        {
            controller = GetComponentInChildren<Controller>();
            controller.Init(anyGoblin);
        }
        
        private void AddToStaticListOfEnemies()
        {  
            AnyGoblin.AllEnemies.Add(this);
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
                AnyGoblin.AllEnemies.Remove(this);
                DropCoin();
            }
        }

        private void Die()
        {
            onDied?.Invoke(this);
            Destroy(gameObject);
            AnyGoblin.AllEnemies.Remove(this);
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