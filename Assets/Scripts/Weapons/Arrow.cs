using System;
using Enemies;
using Interfaces;
using UnityEngine;
using static BuildingsStats;
using IEnemyDamageable = Interfaces.IEnemyDamageable;

namespace Weapons
{
    public class Arrow : MonoBehaviour
    {
        private float _speed = 3f;
        private float _damage;
        
        private float _lifetime = 3;
        
        private Rigidbody2D _rb;
        private LayerMask _layerMask;

        public void Init(float damage, LayerMask layerMask)
        {
            _damage = damage;
            _layerMask = layerMask;
        }
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            Move();

            if (_lifetime <= 0)
                Destroy(gameObject);

            _lifetime -= Time.deltaTime;
        }

        private void Move()
        {
            var moveForward = transform.position + transform.up * (_speed * Time.deltaTime);
            _rb.MovePosition(moveForward);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_layerMask != col.gameObject.layer && col.TryGetComponent(out IEnemyDamageable damageable))
            {
                damageable.TakeDamage(_damage);
                Destroy(gameObject);

            }
            else if (_layerMask != col.gameObject.layer && col.TryGetComponent(out IBuiDamageable buiDamageable))
            {
                buiDamageable.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}

