using Enemies;
using UnityEngine;

namespace Buildings.Castle
{
    public class ArrowsSpawner : MonoBehaviour
    {
        public float cooldown = 2f;
        private float _currentTime = 1f;
        // private Vector2 _castlePos;

        public GameObject arrow;
        public Transform arrowShotPoint;

        // Timer.
        public void Start()
        {
            _currentTime = cooldown;
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
        }

        // Arrow spawn.

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Enemy.Enemy _))
            {
                
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_currentTime >= 0)
                return;

            if (other.gameObject.TryGetComponent(out Enemy.Enemy _))
            {
                var target = other.transform.position;
                SpawnArrow(target);
                
                _currentTime = cooldown;
            }
        }

        private void SpawnArrow(Vector2 target)
        {
            var direction = (target - (Vector2)transform.position).normalized;
            var rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
            Instantiate(arrow, arrowShotPoint.position, rotation);
        }
    }
}
