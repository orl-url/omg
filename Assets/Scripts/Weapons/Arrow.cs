using System;
using Enemies;
using UnityEngine;
using static BuildingsStats;

namespace Weapons
{
    public class Arrow : MonoBehaviour
    {
        private readonly float _speed = AnyBuilding.Castle.arrowSpeed;
        private readonly float _damage = AnyBuilding.Castle.arrowDamage;
        
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var moveForward = transform.position + transform.up * (_speed * Time.deltaTime);
            _rb.MovePosition(moveForward);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}

