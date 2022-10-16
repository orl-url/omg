using Buildings;
using UnityEngine;

public class DefendBonuses : MonoBehaviour
{
    private CardManager _cardManager;
    public void Init(CardManager cardManager)
    {
        _cardManager = cardManager;
    }

    public void IncreaseWallHp()
    {
        _cardManager.wall.GetComponentInChildren<Building>().health = 2;
        _cardManager.PlayGame();
    }
}
