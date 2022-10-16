using UnityEngine;

public class AttackBonuses : MonoBehaviour
{
    private CardManager _cardManager;

    public void Init(CardManager cardManager)
    {
        _cardManager = cardManager;
    }
    
    public void IncreaseArrowDamage()
    {
        _cardManager.arrow.damage += 0.5f;
        DeletingCards();
    }
    
    public void IncreaseCastleAttackSpeed()
    {
        _cardManager.arrowsSpawner.cooldown = 0.3f;
        DeletingCards();
    }

    private void DeletingCards()
    {
        _cardManager.CardFromList("attack");
        _cardManager.DeleteCards();
    }
}
