using UnityEngine;

public class AttackBonuses : MonoBehaviour
{
    private CardManager _cardManager;

    public void Init(CardManager cardManager)
    {
        _cardManager = cardManager;
    }
    
    public void AddArrowDamage()
    {
    }
    
    public void ChangeCastleAttackSpeed()
    {
        _cardManager.arrowsSpawner.cooldown = 0.3f;
        _cardManager.PlayGame();
    }
}
