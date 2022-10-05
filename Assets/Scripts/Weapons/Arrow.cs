using Enemies;
using UnityEngine;

namespace Weapons
{
    public class Arrow : MonoBehaviour
    {
        public float speed = 10f;
        public float lifetime = 2f;
        public float damage = 0.3f;
        
        private Rigidbody2D _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var target = transform.position + transform.up * (speed * Time.deltaTime);
            _rb.MovePosition(target);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}

