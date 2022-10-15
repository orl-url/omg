using System;
using Buildings.Castle;
using UnityEngine;
using Weapons;

public class CardsMethods : MonoBehaviour
{
    private CardManager _cardManager;
    private Arrow _arrow;

    private void Start()
    {
        _cardManager.Init(this);
    }

    public void Init(CardManager cardManager)
    {
        _cardManager = cardManager;
        _arrow = cardManager.arrow;
    }
    
    public void AddArrowDamage()
    {
        print("someessss");
        _cardManager.arrow.damage = 10;
    }

    public void ChangeCastleAttackSpeed()
    {
        _cardManager.arrowsSpawner.cooldown = 0.3f;
    }
}
