using System;
using UnityEngine;
using static BuildingsStats; 
using static BonusesStats;

public class AttackBonuses : MonoBehaviour
{
    private CardManager _cardManager;
    private readonly CardsTypes _typeThisCard = CardsTypes.AttackCard;

    private void Start()
    {
        _cardManager = gameObject.GetComponentInParent<CardManager>();
    }
    
    public void IncreaseArrowDamage()
    {
        AnyBuilding.Castle.arrowDamage += 0.5f;
        DeletingCards();
    }
    
    public void IncreaseCastleAttackSpeed()
    {
        AnyBuilding.Castle.attackCooldown -= 0.15f;
        DeletingCards();
    }

    public void AddArrowWave()
    {
        flagCreateArrowWave = true;
        DeletingCards();
    }
    

    private void DeletingCards()
    {
        _cardManager.DeleteCardFromList(_typeThisCard);
        _cardManager.DestroyScreenCardsAndPlayGame();
    }
}




