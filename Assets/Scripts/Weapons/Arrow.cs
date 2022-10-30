using Enemies;
using Interfaces;
using UnityEngine;
using static BuildingsStats;
using IEnemyDamageable = Interfaces.IEnemyDamageable;

namespace Weapons
{
    public class Arrow : MonoBehaviour
    {
        private float _speed;
        private float _damage;
        
        private Rigidbody2D _rb;

        public void Init(AnyBuilding anyBuilding)
        {
            _speed = anyBuilding.arrowSpeed;
            _damage = anyBuilding.arrowDamage;
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
            if (col.TryGetComponent(out IEnemyDamageable damageable))
            {
                Debug.Log("usingInt");
                damageable.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}

