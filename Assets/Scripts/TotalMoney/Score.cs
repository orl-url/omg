using UnityEngine;
using UnityEngine.UI;

namespace TotalMoney
{
    public class Score : MonoBehaviour
    {
        public float score;
        public Text scoreDisplay;

        private void FixedUpdate()
        {
            scoreDisplay.text = "Gold: " + score.ToString();
        }
    }
}