using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class InactiveShield : MonoBehaviour
    {
        private Castle _castle;
        private Enemy _currentEnemy;
        private Shield _shield;

        private bool _toReturn = false;
        private float _speed = 5f;
        private float _rangeDamage;
        // private bool _flag = false;

        public void Init(Shield shield, Enemy currentEnemy, Castle castle, float rangeDamage)
        {
            _shield = shield;
            _currentEnemy = currentEnemy;
            _castle = castle;
            _rangeDamage = rangeDamage;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move(bool flag = false)
        {
            if (_toReturn == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, _castle.transform.position, _speed * Time.deltaTime);
            }
            else if (_toReturn)
            {
                transform.position = Vector3.MoveTowards(transform.position, _currentEnemy.transform.position, _speed * Time.deltaTime);
                if (flag == true)
                {
                    gameObject.SetActive(false);
                    _shield.gameObject.SetActive(true);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out IBuiDamageable damageable))
            {
                damageable.TakeDamage(_rangeDamage);
                _toReturn = true;
            }

            if (col.gameObject.TryGetComponent(out IEnemyDamageable _))
            {
                Move(true);
            }
        }
    }
}
