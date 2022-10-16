using Buildings;
using UnityEngine;

public class DefendBonuses : MonoBehaviour
{
    private CardManager _cardManager;
    public void Init(CardManager cardManager)
    {
        _cardManager = cardManager;
    }

    public void IncreaseWallsHp() // Увеличивает хп новых стен.
    {
        _cardManager.wall.health += 1f;
        DeletingCards();
    }
    private void DeletingCards()
    {
        _cardManager.CardFromList("defend");
        _cardManager.DeleteCards();
    }
}
