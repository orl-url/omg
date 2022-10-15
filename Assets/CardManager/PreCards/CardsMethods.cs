using System.Collections;
using System.Collections.Generic;
using Buildings;
using Buildings.Castle;
using UnityEngine;
using Weapons;

public class CardsMethods : MonoBehaviour
{
    private Arrow _arrow;
    private ArrowsSpawner _castle;
    
    private CardManager _cardManager;

    public void Init(CardManager cardManager)
    {
        _cardManager = cardManager;
    }

    public void RABOTAI()
    {
        _cardManager.OnClickPlayGame();
    }
    
    public void AddArrowDamage()
    {
        _cardManager.arrow.damage = 10;
    }

    public void ChangeCastleAttackSpeed()
    {
        _cardManager.arrowsSpawner.cooldown = 0.3f;
    }
}
