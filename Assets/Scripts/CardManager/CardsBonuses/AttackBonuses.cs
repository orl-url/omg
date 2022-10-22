using UnityEngine;
using static BuildingsStats; 

public class AttackBonuses : MonoBehaviour
{
    private CardManager _cardManager;

    public void Init(CardManager cardManager)
    {
        _cardManager = cardManager;
    }
    
    public void IncreaseArrowDamage()
    {
        AnyBuilding.caslle.arrowDamage += 0.5f;
        DeletingCards();
    }
    
    public void IncreaseCastleAttackSpeed()
    {
        AnyBuilding.caslle.attackCooldown -= 0.15f;
        DeletingCards();
    }

    private void DeletingCards()
    {
        _cardManager.DeleteCardFromList("attack");
        _cardManager.DestroyCards();
    }
}
