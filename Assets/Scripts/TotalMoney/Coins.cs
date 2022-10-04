using UnityEngine;

public class Coins : MonoBehaviour
{
    public float lifetime = 2f;
    public float value;
    private Score _totalScore; 
    
    
    
    private void Start()
    {
        _totalScore = FindObjectOfType<Score>();   
        Destroy(gameObject, lifetime);
        AddGoldToScore();
    }

    private void AddGoldToScore()
    {
        _totalScore.score += value;
    }
}
