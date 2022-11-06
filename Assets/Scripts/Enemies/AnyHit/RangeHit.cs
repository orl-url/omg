using System;
using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class RangeHit : MonoBehaviour
    {
        protected Castle castle;
       
        // private Collider2D _collider2D;

        protected float rangeDmg;
        private float _rangeAttackCld;

        public void Init(EnemiesStats.AnyGoblin anyGoblin)
        {
            rangeDmg = anyGoblin.rangeDamage;
            _rangeAttackCld = anyGoblin.rangeAttackCooldown;
        }

        private void Start()
        {
            castle = FindObjectOfType<Castle>();
        }

        private void Update()
        {
            // Debug.Log("RangeHit - rangeDmg " + rangeDmg);
        }
    }
}
