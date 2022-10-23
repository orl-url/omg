using System;
using UnityEngine;

namespace TotalMoney
{
    public class Coins : MonoBehaviour
    {
        public float lifetime = 2f;
        public float gold;
        
        private TotalGold _totalTotalGold;
        private Rigidbody2D _rb;

     
        private void Start()
        {
            LifeCycle();
            
            ImpulseToCoin();

            AddGoldToScore();
        }

        private void LifeCycle()
        {
            _rb = GetComponent<Rigidbody2D>();
            _totalTotalGold = FindObjectOfType<TotalGold>();   
            Destroy(gameObject, lifetime);
        }
        
        private void ImpulseToCoin()
        {
            var moveUp = new Vector2(0, 5);
            _rb.AddForce(moveUp, ForceMode2D.Impulse);
        }

        private void AddGoldToScore()
        {
            _totalTotalGold.goldStorage += gold;
        }
    }
}
