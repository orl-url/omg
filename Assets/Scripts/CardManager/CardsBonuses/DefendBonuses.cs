using UnityEngine;

public class DefendBonuses : MonoBehaviour
{
    private CardManager _cardManager;
    private readonly CardsTypes _typeThisCard = CardsTypes.DefendCard;

    private void Start()
    {
        _cardManager = gameObject.GetComponentInParent<CardManager>();
    }

    public void IncreaseWallsHp() // Увеличивает хп новых стен.
    {
        // _cardManager.wall.health += 1f;
        DeletingCards();
    }
    private void DeletingCards()
    {
        _cardManager.DeleteCardFromList(_typeThisCard);
        _cardManager.DestroyScreenCardsAndPlayGame();
    }
}


