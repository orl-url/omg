using System;
using UnityEngine;
using UnityEngine.UI;

namespace TotalMoney
{
    public class TotalGold : MonoBehaviour
    {
        public Text scoreDisplay;
        public PlacingObj shop;
        // public Canvas canvas;
        
        internal float goldStorage;

        private void Start()
        {
            shop.Init(this);
        }

        private void FixedUpdate()
        {
            scoreDisplay.text = "Gold: " + goldStorage.ToString();
        }
    }
}