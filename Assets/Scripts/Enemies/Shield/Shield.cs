using System;
using Common;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    public class Shield : MonoBehaviour
    {
        private float _hp = 100f;

        internal bool isShieldDestroyed = false; 
        

        [SerializeField] private HealthBar healthBar;
        internal void TakeDamage(float damage)
        {
            _hp -= damage;
            healthBar.HealthUpdate(_hp);
            if (_hp <= 0f)
            {
                Destroy();
                isShieldDestroyed = true;
            }
        }

        private void Awake()
        {
            healthBar.maxHealth = _hp;
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }


    }
}
