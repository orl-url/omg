using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score;
    public Text scoreDisplay;

    private void Update()
    {
        scoreDisplay.text = "Gold: " + score.ToString();
    }
}