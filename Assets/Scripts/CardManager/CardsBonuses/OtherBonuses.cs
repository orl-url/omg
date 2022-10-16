using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBonuses : MonoBehaviour
{
    private CardManager _cardManager;
    public void Init(CardManager cardManager)
    {
        _cardManager = cardManager;
    }

    public void IncreaseCoinsValue()
    {
        _cardManager.enemy.coinsForDeath += 1;
    }

}
