using System;
using Common;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public float health = 1f;
        public float damage = 0.25f;
        public float attackCooldown = 0.3f;
        public int coinsForDeath;
   
        
        private float _currentTime;
        
        public GameObject coin;
        public HealthBar healthBar;
        private WavesManager _wavesManager;

        public void Init(WavesManager manager)
        {
            this._wavesManager = manager;
            _wavesManager.enemyList.Add(this);
        }
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
            if (col.gameObject.TryGetComponent (out Buildings.Building building) && _currentTime <= 0f)
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
                Destroy(gameObject);
                _wavesManager.enemyList.Remove(this);
                DropCoin();
                
            }
        }
        
       private void DropCoin()
       {
           for (int x = 1; x <= this.coinsForDeath; x++)
           {
               Instantiate(coin, transform.position, Quaternion.identity);
           }
       }
       
    }
}