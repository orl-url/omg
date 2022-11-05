using System;
using Unity.VisualScripting;
using UnityEngine;
using static EnemiesStats;

namespace Enemies
{
    public class Controller : MonoBehaviour
    {
        private float _speed;
        
        private Rigidbody2D _rb;
        private Vector2 _target;

        private void Start()
        {
            _rb = GetComponentInParent<Rigidbody2D>();
        }

        public void Init(AnyGoblin anyGoblin)
        {
            _speed = anyGoblin.speed;
        }

        private void FixedUpdate()
        {
            if (_rb.bodyType == RigidbodyType2D.Dynamic)
            {
                Move();
            }
        }

        private void Move()
        {
            var direction = (- (Vector2) transform.position).normalized;

            _rb.MovePosition((Vector2) _rb.transform.position + (direction* (_speed*Time.fixedDeltaTime)).normalized/15);
            _rb.transform.up = -direction;
        }
    }
}