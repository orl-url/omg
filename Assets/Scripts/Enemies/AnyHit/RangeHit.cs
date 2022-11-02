using System;
using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class RangeHit : MonoBehaviour
    {
        [SerializeField] private Shield shield;
        [SerializeField] private InactiveShield inactiveShield;
        private Castle _castle;
       
        private Collider2D _collider2D;
        private InactiveShield _createdShield;

        private float _rangeDmg;
        private float _rangeAttackCld;
        private bool _isShieldDestroyed;

        public void Init(EnemiesStats.AnyGoblin anyGoblin)
        {
            _rangeDmg = anyGoblin.rangeDamage;
            _rangeAttackCld = anyGoblin.rangeAttackCooldown;
        }

        private void Start()
        {
            _castle = FindObjectOfType<Castle>();
        }

        private void FixedUpdate()
        {
            _isShieldDestroyed = shield.isShieldDestroyed;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out IBuiDamageable damageable))
            {
                MakeObjIsStatic();
                CreateShield();
            }
        }

        private void MakeObjIsStatic()
        {
            gameObject.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

        private void CreateShield()
        {
            if (_isShieldDestroyed)
                return;
            
            shield.gameObject.SetActive(false);
            
            _createdShield = Instantiate(inactiveShield, shield.transform.position, Quaternion.identity);
            _createdShield.transform.SetParent(this.transform);
            _createdShield.Init(shield,GetComponentInParent<Enemy>(), _castle, _rangeDmg);
        }
    }
}
