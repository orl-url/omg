using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class ThrowHit : RangeHit
{
    public void Hit(BuiDamageableArea building)
    {
        
        building.TakeDamage(rangeDmg);
    }
}
