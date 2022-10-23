using System;
using UnityEngine;
using UnityEngine.UI;

namespace TotalMoney
{
    public class TotalGold : MonoBehaviour
    {
        public Text scoreDisplay;
        public PlacingObj woodenWall;
        
        internal float goldStorage;

        private void Start()
        {
            woodenWall.Init(this);
        }

        private void FixedUpdate()
        {
            scoreDisplay.text = "Gold: " + goldStorage.ToString();
        }
    }
}