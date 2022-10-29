using UnityEngine;
using static BonusesStats;

public class SpecialBonuses : MonoBehaviour
{
    private CardManager _cardManager;
    private readonly CardsTypes _typeThisCard = CardsTypes.SpecialCard;
    
    private void Start()
    {
        _cardManager = gameObject.GetComponentInParent<CardManager>();
    }
    
    public void AddArrowWave()
    {
        flagCreateArrowWave = true;
        DeletingCards();
    }

    public void SecondArrowFromCastle()
    {
        BuildingsStats.AnyBuilding.Castle.arrowsValue += 1;
        DeletingCards();
    }

    // public void GoldPerWave()
    // {
        // _cardManager.totalGold.AddGold();
    // }
    
    private void DeletingCards()
    {
        _cardManager.DeleteCardFromList(_typeThisCard);
        _cardManager.DestroyScreenCardsAndPlayGame();
    }
}
