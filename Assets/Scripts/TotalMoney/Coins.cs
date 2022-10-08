using System;
using UnityEngine;

namespace TotalMoney
{
    public class Coins : MonoBehaviour
    {
        public float lifetime = 2f;
        public float value;
        
        private Score _totalScore;
        private Rigidbody2D _rb;

     
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _totalScore = FindObjectOfType<Score>();   
            Destroy(gameObject, lifetime);
            AddGoldToScore();
            var moveUp = new Vector2(0, 5);
            _rb.AddForce(moveUp, ForceMode2D.Impulse);
        }

        private void AddGoldToScore()
        {
            _totalScore.score += value;
        }
    }
}
