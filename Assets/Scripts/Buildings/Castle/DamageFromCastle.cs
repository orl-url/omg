using System;
using UnityEngine;

namespace Buildings.Castle
{
    public class DamageFromCastle : MonoBehaviour
    {
        public float cooldown = 2f;
        private float _currentTime = 1f;
        private Vector2 _castlePos;

        public GameObject arrow;
        public Transform arrowShotPoint;
        public Vector2 enemyPosition;

        // Timer.
        public void Start()
        {
            _currentTime = cooldown;
            // _castlePos = gameObject.transform.position;
           }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
        }

        // Arrow spawn.

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Enemies.Interaction _))
            {
                
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Enemies.Interaction _) && _currentTime <= 0)
            {
                enemyPosition = other.transform.position;
                // print("enemypos: " + enemyPosition);
                Instantiate(arrow, arrowShotPoint.position, transform.rotation);
                _currentTime = cooldown;
            }

        }
    }
}
