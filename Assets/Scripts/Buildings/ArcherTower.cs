using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Building
{
    private void Awake()
    {
        Init(BuildingsStats.AnyBuilding.Wall);
        SetWeaponParameters();
    }
    
    private void SetWeaponParameters()
    {
        var weapon = GetComponentInChildren<ArrowWeapon>();
        weapon.Init(BuildingsStats.AnyBuilding.ArcherTower);
    }
}
