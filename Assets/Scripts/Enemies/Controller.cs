using System;
using Unity.VisualScripting;
using UnityEngine;
using static EnemiesStats;

namespace Enemies
{
    public class Controller : MonoBehaviour
    {
        //private Transform _castle;
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
            Move();
        }

        private void Move()
        {
            var direction = (- (Vector2) transform.position).normalized;
            _rb.MovePosition((Vector2) _rb.transform.position + (direction* (_speed*Time.fixedDeltaTime)).normalized/15);
        }
    }
}