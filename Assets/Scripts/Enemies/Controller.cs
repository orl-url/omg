using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Enemies
{
    public class Controller : MonoBehaviour
    {
        //private Transform _castle;
        public float speed = 1f;
        public GameObject castle;
        
        private Rigidbody2D _rb;
        private Vector2 _target;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _target = castle.transform.position;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var direction = (_target - (Vector2)transform.position);
            _rb.MovePosition((Vector2) _rb.transform.position + (direction* (speed*Time.fixedDeltaTime)).normalized/15);
        }
    }
}