using System.Collections;
using System.Collections.Generic;
using Buildings;
using Buildings.Castle;
using UnityEngine;
using Weapons;

public class CardsMethods : MonoBehaviour
{
    public Arrow arrow;
    public ArrowsSpawner castle;

    public void AddArrowDamage()
    {
        arrow.damage = 10;
    }

    public void ChangeCastleAttackSpeed()
    {
        castle.cooldown = 0.3f;
    }
}
