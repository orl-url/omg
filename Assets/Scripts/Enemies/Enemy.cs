using System;
using Common;
using UnityEngine;


namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        private float _health;
        private float _damage;
        private float _attackCooldown;
        private float _coinsForDeath;
   
        
        private float _currentTime;
        
        public GameObject coin;
        public HealthBar healthBar;
        private WavesManager _wavesManager;

        public void Init(WavesManager manager, EnemiesStats.AnyGoblin anyGoblin)
        {
            _wavesManager = manager;
            _wavesManager.enemyList.Add(this);
            
            _health = anyGoblin.health;
            _damage = anyGoblin.damage;
            _attackCooldown = anyGoblin.attackCooldown;
            _coinsForDeath = anyGoblin.coinsForDeath;
        }
        
        // Timer for cooldown.
        private void Start()
        {
            _currentTime = _attackCooldown;
        }
        
        private void Update()
        {
            _currentTime -= Time.deltaTime;
        }


        // Damage the castle or some building.

        public void OnCollisionStay2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent (out Building building) && _currentTime <= 0f)
            {
                building.TakeDamage(_damage);
                
                _currentTime = _attackCooldown;
            }
            else if (col.gameObject.TryGetComponent (out CastleBuilding castle) && _currentTime <= 0f)
            {
                castle.TakeDamage(_damage);
                
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
                Destroy(gameObject);
                _wavesManager.enemyList.Remove(this);
                DropCoin();
                
            }
        }
        
       private void DropCoin()
       {
           for (int x = 1; x <= this._coinsForDeath; x++)
           {
               Instantiate(coin, transform.position, Quaternion.identity);
           }
       }
       
    }
}