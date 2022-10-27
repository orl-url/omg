using System;
using UnityEngine;
using static EnemiesStats;
using static BuildingsStats;

public class OtherBonuses : MonoBehaviour
{
    private CardManager _cardManager;
    private readonly CardsTypes _typeThisCard = CardsTypes.OtherCard;

    private void Start()
    {
        _cardManager = gameObject.GetComponentInParent<CardManager>();
    }


    public void IncreaseCoinsValue()
    {
        AnyGoblin.DoForAllElements(AnyGoblin.EnemyStats.CoinsForDeath, 5);
        DeletingCards();
    }
    
    private void DeletingCards()
    {
        _cardManager.DeleteCardFromList(_typeThisCard);
        _cardManager.DestroyScreenCardsAndPlayGame();
    }

    public void SlowDownTheEnemy()
    {
        AnyGoblin.DoForAllElements(AnyGoblin.EnemyStats.Speed, 0.9f);
        DeletingCards();
    }

    public void IncreaseDamageAreaRadius()
    {
        AnyBuilding.Castle.attackRadius *= 2;
        DeletingCards();
    }
}
