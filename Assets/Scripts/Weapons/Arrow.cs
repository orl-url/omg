using System;
using Enemies;
using UnityEngine;
using static BuildingsStats;

namespace Weapons
{
    public class Arrow : MonoBehaviour
    {
        private float _speed;
        private float _damage;
        
        private Rigidbody2D _rb;

        private void Init(AnyBuilding castle)
        {
            _damage = castle.arrowDamage;
            _speed = castle.arrowSpeed;
        }


        private void Start()
        {
            this.Init(AnyBuilding.caslle);
        }

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

